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
using CommonCom;
using LiveSplit.JumpKingWS.Split;
using LiveSplit.JumpKingWS.State;
using LiveSplit.JumpKingWS.UI;

namespace LiveSplit.JumpKingWS.Communication;

public static class CommunicationWrapper {
    public static bool Connected => comm is { Connected: true };
    private static CommunicationAdapterAutoSplitter? comm;
    
    static CommunicationWrapper()
    {
        // Stop communicating thread when process end
        AppDomain.CurrentDomain.ProcessExit += (sender, e) => Stop();
    }


    public static void Start() {
        if (comm != null) {
            Console.Error.WriteLine("Tried to start the communication adapter while already running!");
            return;
        }

        comm = new CommunicationAdapterAutoSplitter();
    }
    public static void Stop() {
        if (comm == null) {
            Console.Error.WriteLine("Tried to stop the communication adapter while not running!");
            return;
        }

        comm.Dispose();
        comm = null;
    }

    private static void OnConnectionChanged() {
    }

    #region Data


    #endregion

    #region Actions

    public static void OnSeeScreen(int index) {
        ScreenState.AddSeenScreen(index);
    }

    public static void OnLandOnScreen(int index) {
        ScreenState.AddLandedScreen(index);
    }

    public static void OnAddItems(Item item, int count) {
        ItemState.AddItems(item, count);
    }

    public static void OnAchievement(Achievement code) {
        AchievementState.SetAchievement(code);
    }

    public static void OnRavenFlee(string ravenName, int homeIndex) {
        RavenState.AddRavenFlee(ravenName, homeIndex);
    }

    public static void OnUpdateTicks(int ticks) {
        Component.UpdateGameTime(ticks);
        SplitManager.UpdatSplits();
    }

    public static void OnGameLoopStart(int ticks) {
        if (Settings.isAutoStartSplit) Component.Timer?.Start();
        Component.UpdateGameTime(ticks);
        EndingState.Reset();
    }

    public static void OnWin(Ending ending) {
        ScreenState.Reset();
        RavenState.Reset();
        EndingState.SetEnding(ending);
    }

    public static void OnRestart() {
        if (Settings.isAutoResetSplit) Component.Timer?.Reset();
        ScreenState.Reset();
        RavenState.Reset();
    }

    public static void OnExitToMenu() {
        ScreenState.Reset();
        RavenState.Reset();
    }

    public static void OnGiveUp() {
        
    }

    #endregion
}
