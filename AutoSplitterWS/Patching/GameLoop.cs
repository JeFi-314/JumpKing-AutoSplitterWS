using HarmonyLib;
using JK = JumpKing.GameManager;
using System;
using System.Reflection;
using System.Diagnostics;
using AutoSplitterWS.Communication;
using JumpKing;
using JumpKing.Util;
using Microsoft.Xna.Framework;
using BehaviorTree;

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

        MethodInfo Draw = AccessTools.Method(type, nameof(JK.GameLoop.Draw));
        harmony.Patch(
            Draw,
            postfix: new HarmonyMethod(AccessTools.Method(typeof(GameLoop), nameof(postDraw)))
        );
    }

    private static void preOnNewRun() {
        var ticks = AchievementManagerInstance.Field("m_all_time_stats").Field<int>("_ticks");
        CommunicationWrapper.SendGameLoopStart(ticks.Value);
    }

    private static void postDraw(GameLoop __instance)
    {
        if (AutoSplitterWS.Prefs.IsShowScreenNumber &&
            !Traverse.Create(__instance).Field("m_pause_manager").Property<bool>("IsPaused").Value)
        {
            string text = $"Screen-{Camera.CurrentScreen+1}";
                
            TextHelper.DrawString(
                Game1.instance.contentManager.font.MenuFont,
                text,
                new Vector2(480f, 0f),
                Color.White, new Vector2(1, 0), true
            );
        }
    }

}