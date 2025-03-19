using AutoSplitterWS.Communication;
using HarmonyLib;
using System;
using System.Reflection;

namespace AutoSplitterWS.Patching;

internal class OnGiveUpAch
{
    public OnGiveUpAch(Harmony harmony)
    {
        Type type = AccessTools.TypeByName("JumpKing.MiscSystems.Achievements.OnGiveUpAch");
        MethodInfo MyRun = AccessTools.Method(type, "MyRun");
        harmony.Patch(
            MyRun,
            postfix: new HarmonyMethod(AccessTools.Method(typeof(OnGiveUpAch), nameof(postMyRun)))
        );
    }
    private static void postMyRun() {
        CommunicationWrapper.SendGiveUp();
    }
}