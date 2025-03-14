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

using System;
using System.Diagnostics;

namespace AutoSplitterWS.Communication;

public static class CommunicationWrapper {

    public static bool Connected => comm is { Connected: true };
    private static CommunicationAdapterJumpKing comm;

    static CommunicationWrapper()
    {
        // Stop communicating thread when process end
        AppDomain.CurrentDomain.ProcessExit += (sender, e) => Stop();
    }

    public static void Start() {
        if (comm != null) {
            Debug.WriteLine("[Wrapper] Tried to start the communication adapter while already running!");
            return;
        }

        comm = new CommunicationAdapterJumpKing();
    }
    public static void Stop() {
        if (comm == null) {
            Debug.WriteLine("[Wrapper] Tried to stop the communication adapter while not running!");
            return;
        }

        comm.Dispose();
        comm = null;
    }

    public static void ChangeStatus() {
        if (comm == null) {
            Start();
        } else if (comm != null) {
            Stop();
        }
    }

    #region Actions

    public static void SendSeeScreen(int index) {
        if (!Connected) {
            return;
        }

        comm.WriteSeeScreen(index);
    }

    public static void SendLandOnScreen(int index) {
        if (!Connected) {
            return;
        }

        comm.WriteLandOnScreen(index);
    }

    public static void SendAddItems(int item, int count) {
        if (!Connected || count <= 0) {
            return;
        }

        comm.WriteAddItems(item, count);
    }

    public static void SendAchievement(int code) {
        if (!Connected) {
            return;
        }
        
        comm.WriteAchievement(code);
    }

    public static void SendRavenFlee(string ravenName, int homeIndex) {
        if (!Connected) {
            return;
        }

        comm.WriteRavenFlee(ravenName, homeIndex);
    }

    public static void SendGameLoopStart(int ticks) {
        if (!Connected) {
            return;
        }

        comm.WriteGameLoopStart(ticks);
    }
    public static void SendWin(int ending) {
        if (!Connected) {
            return;
        }

        comm.WriteWin(ending);
    }
    public static void SendRestart() {
        if (!Connected) {
            return;
        }

        comm.WriteRestart();
    }
    public static void SendExitToMenu() {
        if (!Connected) {
            return;
        }

        comm.WriteExitToMenu();
    }
    public static void SendGiveUp() {
        if (!Connected) {
            return;
        }

        comm.WriteGiveUp();
    }

    public static void SendUpdateTicks(int ticks) {
        if (!Connected) {
            return;
        }

        comm.WriteUpdateTicks(ticks);
    }

    #endregion
}
