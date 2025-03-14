using System;
using System.Reflection;
using AutoSplitterWS.Communication;
using HarmonyLib;
using JumpKing.MiscSystems.Achievements;

namespace AutoSplitterWS.Patching;

internal class AchievementRegister
{
    public AchievementRegister(Harmony harmony) {
        Type type = AccessTools.TypeByName("JumpKing.MiscSystems.Achievements.AchievementRegister");
        MethodInfo RegisterAchievement = AccessTools.Method(type, "RegisterAchievement");

        harmony.Patch(
            RegisterAchievement,
            prefix: new HarmonyMethod(AccessTools.Method(typeof(AchievementRegister), nameof(preRegisterAchievement)))
        );
    }

    private static void preRegisterAchievement(AchievementCode p_achievement) {
        CommunicationWrapper.SendAchievement((int) p_achievement);
    }
}