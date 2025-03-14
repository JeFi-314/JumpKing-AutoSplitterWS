using HarmonyLib;
using JK = JumpKing;
using System;
using System.Reflection;
using AutoSplitterWS.Communication;

namespace AutoSplitterWS.Patching;

internal class JumpGame
{
    private static Traverse AchievementManagerInstance;
    public JumpGame(Harmony harmony) {
        AchievementManagerInstance = Traverse.Create(AccessTools.Field("JumpKing.MiscSystems.Achievements.AchievementManager:instance").GetValue(null));

        Type type = typeof(JK.JumpGame);
        
        MethodInfo Update = AccessTools.Method(type, nameof(JK.JumpGame.Update));
        harmony.Patch(
            Update,
            postfix: new HarmonyMethod(AccessTools.Method(typeof(JumpGame), nameof(postUpdate)))
        );

        MethodInfo OnExit = AccessTools.Method(type, nameof(JK.JumpGame.OnExit));
        harmony.Patch(
            OnExit,
            prefix: new HarmonyMethod(AccessTools.Method(typeof(JumpGame), nameof(preOnExit)))
        );
    }

    private static void postUpdate() {
        var ticks = AchievementManagerInstance.Field("m_all_time_stats").Field<int>("_ticks");
        CommunicationWrapper.SendUpdateTicks(ticks.Value);
    }
    private static void preOnExit() {
        CommunicationWrapper.Stop();
    }
}