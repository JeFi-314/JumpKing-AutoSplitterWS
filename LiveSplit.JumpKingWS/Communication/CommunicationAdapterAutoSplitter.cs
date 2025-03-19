/*
The MIT License (MIT)

Copyright (c) 2018 - 2025 Everest Team

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using CommonCom;
using CommonCom.Util;

namespace LiveSplit.JumpKingWS.Communication;

public sealed class CommunicationAdapterAutoSplitter() : CommunicationAdapterBase(Location.AutoSplitter)
{
    public void ForceReconnect()
    {
        if (Connected) {
            LogVerbose($"Sent message | {MessageID.Reset}");
            WriteMessageNow(MessageID.Reset, _ => {});
        }
        FullReset();
    }

    protected override void FullReset()
    {
        CommunicationWrapper.Stop();
        CommunicationWrapper.Start();
    }

    protected override void OnProtocolVersionMismatch(ushort otherVersion) {
        LogError($"Protocal version mismatch: LiveSplit={ProtocolVersion}, JumpKing={otherVersion}.");
        // Task.Run(() => CommunicationWrapper.Stop());
    }

    protected override void OnConnectionChanged()
    {
        if (Connected) {
        } else {
        }
    }

    protected override void HandleMessage(MessageID messageId, BinaryReader reader)
    {
        switch (messageId) {
            case MessageID.SeeScreen:
                int seeScreenIndex = reader.ReadObject<int>();
                LogInfo($"Received message {MessageID.SeeScreen}: {seeScreenIndex}");
                Component.ActionQueue.Enqueue(() => CommunicationWrapper.OnSeeScreen(seeScreenIndex));
                break;

            case MessageID.LandOnScreen:
                int landScreenIndex = reader.ReadObject<int>();
                LogInfo($"Received message {MessageID.LandOnScreen}: {landScreenIndex}");
                Component.ActionQueue.Enqueue(() => CommunicationWrapper.OnLandOnScreen(landScreenIndex));
                break;

            case MessageID.AddItems:
                Item item = (Item)reader.ReadObject<int>();
                int count = reader.ReadObject<int>();
                LogInfo($"Received message {MessageID.AddItems}: {item.GetName()}, {count}");
                Component.ActionQueue.Enqueue(() => CommunicationWrapper.OnAddItems(item, count));
                break;

            case MessageID.GetAchievement:
                Achievement code = (Achievement)reader.ReadObject<int>();
                LogInfo($"Received message {MessageID.GetAchievement}: {code.GetName()}");
                Component.ActionQueue.Enqueue(() => CommunicationWrapper.OnAchievement(code));
                break;

            case MessageID.RavenFlee:
                string ravenName = reader.ReadObject<string>();
                int homeIndex = reader.ReadObject<int>();
                LogInfo($"Received message {MessageID.RavenFlee}: {ravenName}, {homeIndex}");
                Component.ActionQueue.Enqueue(() => CommunicationWrapper.OnRavenFlee(ravenName, homeIndex));
                break;

            case MessageID.UpdateTicks:
                int ticks = reader.ReadObject<int>();
                LogVerbose($"Received message {MessageID.UpdateTicks}: {ticks}");
                Component.ActionQueue.Enqueue(() => CommunicationWrapper.OnUpdateTicks(ticks));
                break;

            case MessageID.GameLoopStart:
                ticks = reader.ReadObject<int>();
                LogInfo($"Received message {MessageID.GameLoopStart}: {ticks}");
                Component.ActionQueue.Enqueue(() => CommunicationWrapper.OnGameLoopStart(ticks));
                break;

            case MessageID.Win:
                Ending ending = (Ending)reader.ReadObject<int>();
                LogInfo($"Received message {MessageID.Win}: {ending.GetName()}");
                Component.ActionQueue.Enqueue(() => CommunicationWrapper.OnWin(ending));
                break;

            case MessageID.Restart:
                LogInfo($"Received message {MessageID.Restart}");
                Component.ActionQueue.Enqueue(() => CommunicationWrapper.OnRestart());
                break;

            case MessageID.ExitToMenu:
                LogInfo($"Received message {MessageID.ExitToMenu}");
                Component.ActionQueue.Enqueue(() => CommunicationWrapper.OnExitToMenu());
                break;

            case MessageID.GiveUp:
                LogInfo($"Received message {MessageID.GiveUp}");
                Component.ActionQueue.Enqueue(() => CommunicationWrapper.OnGiveUp());
                break;

            default:
                LogError($"Received unknown message ID: {messageId}");
                break;
        }
    }


#if DEBUG
    // protected override void LogVerbose(string message) => Debug.WriteLine($"[Com Verbose] {message}");
    protected override void LogVerbose(string message) {}
    protected override void LogInfo(string message) => Debug.WriteLine($"[Com Info] {message}");
    protected override void LogError(string message) => Debug.WriteLine($"[Com Error] {message}");
#else
    protected override void LogVerbose(string message) {}
    protected override void LogInfo(string message) {}
    protected override void LogError(string message) {}
#endif
}
