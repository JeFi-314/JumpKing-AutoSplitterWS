using HarmonyLib;
using JK = JumpKing.GameManager;
using System;
using System.Reflection;
using System.Diagnostics;
using AutoSplitterWS.Communication;

namespace AutoSplitterWS.Patching;

internal class GameLoop
{
    private static Traverse AchievementManagerInstance;

    public GameLoop(Harmony harmony) {
        AchievementManagerInstance = Traverse.Create(AccessTools.Field("JumpKing.MiscSystems.Achievements.AchievementManager:instance").GetValue(null));

        Type type = typeof(JK.GameLoop);
        MethodInfo OnNewRun = AccessTools.Method(type, "OnNewRun");

        harmony.Patch(
            OnNewRun,
            prefix: new HarmonyMethod(AccessTools.Method(typeof(GameLoop), nameof(preOnNewRun)))
        );
    }

    private static void preOnNewRun() {
        var ticks = AchievementManagerInstance.Field("m_all_time_stats").Field<int>("_ticks");
        CommunicationWrapper.SendGameLoopStart(ticks.Value);
    }
}