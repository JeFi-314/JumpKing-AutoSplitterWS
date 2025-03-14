// /*
// The MIT License (MIT)

// Copyright (c) 2018 - 2025 Everest Team

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// */

// using System;
// using System.Collections.Concurrent;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.IO;
// using System.IO.Pipes;
// using System.Runtime.InteropServices;
// using System.Text;
// using System.Threading;
// using System.Threading.Tasks;

// namespace Communication;
// public abstract class CommunicationAdapterBase : IDisposable
// {
//     // Define the roles: JumpKing (server) and Autosplitter (client)
//     protected enum Location { JumpKing, Autosplitter }

//     private bool connected = false;
//     public bool Connected
//     {
//         get => connected;
//         private set
//         {
//             if (connected == value)
//                 return;
//             connected = value;
//             LogInfo(connected ? "Connected" : "Disconnected");
//             OnConnectionChanged();
//         }
//     }

//     // Interval for sending Ping messages. Must be shorter than TimeoutDelay
//     private static readonly TimeSpan PingInterval = TimeSpan.FromSeconds(1);
//     // Amount of time to wait before disconnecting when not receiving messages.
//     private static readonly TimeSpan TimeoutDelay = TimeSpan.FromSeconds(3);

//     private DateTime lastPing = DateTime.UtcNow;
//     private DateTime lastMessage = DateTime.UtcNow;

//     // Using a single duplex named pipe for bidirectional communication.
//     // The pipe name is defined as "JumpKing_Duplex".
//     private readonly NamedPipeServerStream pipeServer;
//     private readonly NamedPipeClientStream pipeClient;
//     private readonly PipeStream pipe;

//     private readonly Thread thread;
//     private bool runThread = true;

//     // Queue for outgoing messages (MessageID and its serialization delegate)
//     private readonly ConcurrentQueue<(MessageID, Action<BinaryWriter>)> messageQueue = new();

//     // Protocol version for ABI compatibility check
//     protected const ushort ProtocolVersion = 1;

//     private const int BufferCapacity = 1024 * 1024; // 1MB should be enough for everything
//     // Update rate in milliseconds (approximately 60 FPS)
//     protected readonly TimeSpan UpdateRate = TimeSpan.FromMilliseconds(1000/60);

//     /// <summary>
//     /// Constructor: Establishes a duplex named pipe communication based on the provided role.
//     /// </summary>
//     protected CommunicationAdapterBase(Location location)
//     {
//         if (location == Location.JumpKing)
//         {
//             // For JumpKing (Server):
//             // Create a NamedPipeServerStream for duplex communication on pipe "JumpKing_Duplex"
//             pipeServer = new NamedPipeServerStream("JumpKing_Duplex", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
//             pipe = pipeServer;
//         }
//         else if (location == Location.Autosplitter)
//         {
//             // For Autosplitter (Client):
//             // Create a NamedPipeClientStream for duplex communication on pipe "JumpKing_Duplex"
//             pipeClient = new NamedPipeClientStream(".", "JumpKing_Duplex", PipeDirection.InOut, PipeOptions.Asynchronous);
//             pipe = pipeClient;
//         }

//         // Start the communication update thread
//         thread = new Thread(() =>
//         {
//             LogInfo("Starting communication using a Duplex Named Pipe...");

//             if (location == Location.JumpKing)
//             {
//                 LogInfo("Waiting for Autosplitter to connect on duplex pipe...");
//                 pipeServer.WaitForConnection();
//                 LogInfo("Autosplitter connected on duplex pipe.");
//             }
//             else
//             {
//                 LogInfo("Connecting to JumpKing's duplex pipe...");
//                 pipeClient.Connect();
//                 LogInfo("Connected on duplex pipe.");
//             }

//             // Set a read/write timeout to avoid indefinite blocking on reading
//             // pipe.ReadTimeout = pipe.WriteTimeout = UpdateRate;
            
//             var lastCrash = DateTime.UtcNow;
//             try
//             {
//                 UpdateThread();
//             }
//             catch (Exception ex)
//             {
//                 // In case of exception, log and reset communication if needed
//                 LogError($"Thread crashed: {ex}");
//                 Task.Run(FullReset);
//             }
//         })
//         { Name = "JumpKingCom" };
//         thread.Start();
//         LogInfo("Communication started using a Duplex Named Pipe.");
//     }

//     public void Dispose()
//     {
//         LogInfo("Stopping communication...");
//         runThread = false;
//         thread.Join();
//         try { pipe.Close(); pipe.Dispose(); } catch { }
//         LogInfo("Communication stopped.");
//     }

//     /// <summary>
//     /// The main update thread for communication.
//     /// It reads incoming messages, sends queued outgoing messages,
//     /// and handles ping/timeout logic.
//     /// </summary>
//     private void UpdateThread()
//     {
//         Stopwatch stopwatch = new Stopwatch();
//         while (runThread)
//         {
//             stopwatch.Restart();

//             var now = DateTime.UtcNow;
//             bool needAfterRead = false; // flag to indicate if we should perform after-read handling

//             // Read incoming messages
//             try
//             {
//                 // Read the 4-byte length prefix
//                 byte[] lengthBytes = new byte[4];
//                 int bytesRead = 0;
//                 try
//                 {
//                     bytesRead = pipe.Read(lengthBytes, 0, 4);
//                 }
//                 catch (TimeoutException)
//                 {
//                     needAfterRead = true;
//                 }

//                 if (!needAfterRead)
//                 {
//                     if (bytesRead == 0)
//                     {
//                         Connected = false;
//                         needAfterRead = true;
//                     }
//                 }

//                 if (!needAfterRead)
//                 {
//                     if (bytesRead < 4)
//                     {
//                         // Incomplete header received, skip this cycle
//                         continue;
//                     }
//                     int messageLength = BitConverter.ToInt32(lengthBytes, 0);
//                     if (messageLength <= 0)
//                         continue;

//                     // Read the complete message payload
//                     byte[] payload = new byte[messageLength];
//                     int totalRead = 0;
//                     while (totalRead < messageLength)
//                     {
//                         int readNow = pipe.Read(payload, totalRead, messageLength - totalRead);
//                         if (readNow == 0)
//                             break;
//                         totalRead += readNow;
//                     }
//                     if (totalRead < messageLength)
//                         continue; // Incomplete message, skip processing

//                     // Deserialize the message using MemoryStream and BinaryReader
//                     using (var ms = new MemoryStream(payload))
//                     using (var reader = new BinaryReader(ms))
//                     {
//                         MessageID messageId = (MessageID)reader.ReadByte();
//                         if (messageId == MessageID.Ping)
//                         {
//                             ushort version = reader.ReadUInt16();
//                             if (version != ProtocolVersion)
//                             {
//                                 OnProtocolVersionMismatch(version);
//                                 Connected = false;
//                             }
//                         }
//                         else if (messageId == MessageID.Reset)
//                         {
//                             LogVerbose("Received Reset message");
//                             Connected = false;
//                             Task.Run(FullReset);
//                             return;
//                         }
//                         else
//                         {
//                             HandleMessage(messageId, reader);
//                         }
//                     }
//                     lastMessage = now;
//                     Connected = true;
//                 }
//             }
//             catch (TimeoutException)
//             {
//                 // No data received within the timeout period
//             }
//             catch (IOException ioEx)
//             {
//                 LogError($"Error reading from pipe: {ioEx}");
//                 Connected = false;
//             }

//             // After-read handling: if no message has been received within the timeout, mark as disconnected
//             if (now - lastMessage > TimeoutDelay)
//                 Connected = false;

//             // Write queued outgoing messages if connected
//             if (Connected)
//             {
//                 while (messageQueue.TryDequeue(out var message))
//                 {
//                     WriteMessage(message.Item1, message.Item2);
//                 }
//             }

//             // Periodically send a Ping message when no other messages are pending
//             if (now - lastPing > PingInterval)
//             {
//                 WriteMessage(MessageID.Ping, writer =>
//                 {
//                     writer.Write(ProtocolVersion);
//                 });
//                 lastPing = now;
//             }
//         }

//         var sleepTime = UpdateRate - stopwatch.Elapsed;
//         if (sleepTime > TimeSpan.Zero) 
//         {
//             Thread.Sleep(sleepTime);
//         }
//     }

//     /// <summary>
//     /// Queues a message to be sent in the next update cycle.
//     /// </summary>

//     protected void QueueMessage(MessageID messageId, Action<BinaryWriter> serialize)
//     {
//         messageQueue.Enqueue((messageId, serialize));
//     }

//     /// <summary>
//     /// Immediately writes a message to the pipe.
//     /// </summary>
//     protected void WriteMessageNow(MessageID messageId, Action<BinaryWriter> serialize)
//     {
//         WriteMessage(messageId, serialize);
//     }

//     /// <summary>
//     /// Writes a message to the pipe.
//     /// </summary>
//     private void WriteMessage(MessageID messageId, Action<BinaryWriter> serialize)
//     {
//         try
//         {
//             lock (pipe) // Ensure thread-safe writes using a lock on the pipe
//             {
//                 using var writer = new BinaryWriter(pipe, Encoding.UTF8, leaveOpen: true);
//                 writer.Write((byte)messageId);
//                 serialize(writer);
//                 pipe.Flush();
//             }
//         }
//         catch (IOException ex)
//         {
//             LogError($"Error writing to pipe: {ex}");
//             Connected = false;
//         }
//     }

//     /// <summary>
//     /// Invoked when the protocol version of the remote side does not match.
//     /// </summary>
//     protected virtual void OnProtocolVersionMismatch(ushort otherVersion) { }

//     /// <summary>
//     /// Abstract method called when the connection state changes.
//     /// </summary>
//     protected abstract void OnConnectionChanged();

//     /// <summary>
//     /// Abstract method invoked to perform a full communication reset.
//     /// </summary>
//     protected abstract void FullReset();

//     /// <summary>
//     /// Abstract method for handling non-ping, non-reset messages.
//     /// </summary>
//     protected abstract void HandleMessage(MessageID messageId, BinaryReader reader);

//     protected abstract void LogInfo(string message);
//     protected abstract void LogVerbose(string message);
//     protected abstract void LogError(string message);
// }
