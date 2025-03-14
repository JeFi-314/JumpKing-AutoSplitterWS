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
using CommonCom;
using CommonCom.Util;

namespace AutoSplitterWS.Communication;

public sealed class CommunicationAdapterJumpKing() : CommunicationAdapterBase(Location.JumpKing) {
    protected override void FullReset() {
        CommunicationWrapper.Stop();
        CommunicationWrapper.Start();
    }

    protected override void OnConnectionChanged() {
        if (Connected) {
            // CommunicationWrapper.Send();
        }
    }

    protected override void HandleMessage(MessageID messageId, BinaryReader reader) {
        switch (messageId) {
            case MessageID.GetAchievement:
                break;

            default:
                LogError($"Received unknown message ID: {messageId}");
                break;
        }
    }

    #region WriteMessage

    public void WriteSeeScreen(int index) {
        QueueMessage(MessageID.SeeScreen, writer => writer.WriteObject(index));
        LogVerbose($"Sent message | {MessageID.SeeScreen}-{index}");
    }
    public void WriteLandOnScreen(int index) {
        QueueMessage(MessageID.LandOnScreen, writer => writer.WriteObject(index));
        LogVerbose($"Sent message | {MessageID.LandOnScreen}-{index}");
    }
    public void WriteAddItems(int item, int count) {
        QueueMessage(MessageID.AddItems, writer => {
            writer.WriteObject(item);
            writer.WriteObject(count);
        });
        LogVerbose($"Sent message | {MessageID.AddItems}-{((Item)item).GetName()}, {count}");
    }
    public void WriteAchievement(int code) {
        QueueMessage(MessageID.GetAchievement, writer => writer.WriteObject(code));
        LogVerbose($"Sent message | {MessageID.GetAchievement}-{((Achievement)code).GetName()}");
    }
    public void WriteRavenFlee(string ravenName, int homeIndex) {
        QueueMessage(MessageID.RavenFlee, writer => {
            writer.WriteObject(ravenName);
            writer.WriteObject(homeIndex);
        });
        LogVerbose($"Sent message | {MessageID.RavenFlee}-{ravenName}, {homeIndex}");
    }
    public void WriteUpdateTicks(int ticks) {
        QueueMessage(MessageID.UpdateTicks, writer => writer.WriteObject(ticks));
        // LogVerbose($"Sent message | {MessageID.UpdateTicks}-{ticks}");
    }
    public void WriteGameLoopStart(int ticks) {
        QueueMessage(MessageID.GameLoopStart, writer => {writer.WriteObject(ticks);});
        LogVerbose($"Sent message | {MessageID.GameLoopStart}-{ticks}");
    }
    public void WriteWin(int ending) {
        QueueMessage(MessageID.Win, writer => writer.WriteObject(ending));
        LogVerbose($"Sent message | {MessageID.Win}-{((Ending)ending).GetName()}");
    }
    public void WriteRestart() {
        QueueMessage(MessageID.Restart, writer => {});
        LogVerbose($"Sent message | {MessageID.Restart}");
    }
    public void WriteExitToMenu() {
        QueueMessage(MessageID.ExitToMenu, writer => {});
        LogVerbose($"Sent message | {MessageID.ExitToMenu}");
    }
    public void WriteGiveUp() {
        QueueMessage(MessageID.GiveUp, writer => {});
        LogVerbose($"Sent message | {MessageID.GiveUp}");
    }
    
    #endregion

#if DEBUG
    protected override void LogInfo(string message) => Debug.WriteLine($"[Com Info] {message}");
    protected override void LogVerbose(string message) => Debug.WriteLine($"[Com Verbose] {message}");
    protected override void LogError(string message) => Debug.WriteLine($"[Com Error] {message}");
#else
    protected override void LogInfo(string message) {}
    protected override void LogVerbose(string message) {}
    protected override void LogError(string message) {}
#endif
}
