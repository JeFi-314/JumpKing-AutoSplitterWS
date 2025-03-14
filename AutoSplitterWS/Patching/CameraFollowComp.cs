using System;
using System.Reflection;
using AutoSplitterWS.Communication;
using BehaviorTree;
using HarmonyLib;
using JumpKing;

namespace AutoSplitterWS.Patching;

internal class CameraFollowComp
{
    private static int lastIndex1;
    private static bool lastOnGround;
    public CameraFollowComp(Harmony harmony) {
        Type type = AccessTools.TypeByName("JumpKing.Player.CameraFollowComp");
        MethodInfo Update = AccessTools.Method(type, "Update");

        harmony.Patch(
            Update,
            postfix: new HarmonyMethod(AccessTools.Method(typeof(CameraFollowComp), nameof(postUpdate)))
        );
    }

    private static void postUpdate() {
        // +1 for one-indexing
        int index1 = Camera.CurrentScreen+1;
        bool isOnGround = Traverse.Create(JumpKing.GameManager.GameLoop.m_player)
            .Field("m_is_on_ground_state")
            .Property<BTresult>("last_result").Value == BTresult.Success;
        if (lastIndex1 != index1) {
            if (isOnGround) 
                CommunicationWrapper.SendLandOnScreen(index1);
            else
                CommunicationWrapper.SendSeeScreen(index1);
        }
        else {
            if (lastOnGround==false && isOnGround==true)
                CommunicationWrapper.SendLandOnScreen(index1);
        }
        lastIndex1 = index1;
        lastOnGround = isOnGround;
    }

    public static void Reset() {
        lastIndex1 = 0;
        lastOnGround = false;
    }
}