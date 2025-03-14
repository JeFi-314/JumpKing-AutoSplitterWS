using System;
using System.Reflection;
using HarmonyLib;
using JK = JumpKing.MiscEntities.Raven;
using JumpKing.MiscEntities;
using JumpKing.MiscEntities.Raven;
using System.Diagnostics;
using AutoSplitterWS.Communication;

namespace AutoSplitterWS.Patching;

internal class RavenFlee
{
    public RavenFlee(Harmony harmony) {
        Type type = typeof(JK.RavenFlee);
        MethodInfo OnNewRun = AccessTools.Method(type, "OnNewRun");

        harmony.Patch(
            OnNewRun,
            prefix: new HarmonyMethod(AccessTools.Method(typeof(RavenFlee), nameof(preOnNewRun)))
        );
    }

    private static void preOnNewRun(RavenFlee __instance) {
        var raven = Traverse.Create(__instance).Property("raven");
        string ravenName = raven.Field<RavenSettings>("m_settings").Value.name;
        int homeIndex = raven.Field<RavenState>("m_state").Value.home_screen;
        CommunicationWrapper.SendRavenFlee(ravenName, homeIndex);
    }
}