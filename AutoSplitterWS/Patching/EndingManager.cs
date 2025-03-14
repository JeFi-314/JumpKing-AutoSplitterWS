using CommonCom;
using HarmonyLib;
using JumpKing.GameManager.MultiEnding;
using System;
using System.Reflection;

namespace AutoSplitterWS.Patching;

public class EndingManager
{
    public EndingManager(Harmony harmony)
    {
        Type type = AccessTools.TypeByName("JumpKing.GameManager.MultiEnding.EndingManager");
        MethodInfo CheckWin = type.GetMethod("CheckWin");
        harmony.Patch(
            CheckWin,
            postfix: new HarmonyMethod(AccessTools.Method(typeof(EndingManager), nameof(postCheckWin)))
        );
    }
    private static void postCheckWin(IEnding p_ending, bool __result) {
        if (__result) {
            AutoSplitterWS.isWin = true;
            AutoSplitterWS.Ending = p_ending.GetBabeType();
        }
    }
}