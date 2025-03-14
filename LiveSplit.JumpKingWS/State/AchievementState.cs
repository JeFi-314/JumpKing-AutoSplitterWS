using System;
using System.Collections.Generic;
using System.Linq;
using CommonCom;

namespace LiveSplit.JumpKingWS.State;
public static class AchievementState
{
    private static List<bool> achievementList;

    static AchievementState() {
        int length = Enum.GetValues(typeof(Achievement)).Length;
        achievementList = [.. Enumerable.Repeat(false, length)];
    }

    public static void Reset() {
        for (int i=0; i<achievementList.Count; i++) {
            achievementList[i] = false;
        }
    }

    public static void SetAchievement(Achievement code) {
        achievementList[(int)code] = true;
    }
    public static bool HasAchievement(Achievement code) {
        return achievementList[(int)code];
    }
}