using System.Collections.Generic;

namespace LiveSplit.JumpKingWS.State;
public static class ScreenState
{
    private static HashSet<int> seenScreensSet;
    private static HashSet<int> landedScreensSet;

    static ScreenState() {
        seenScreensSet = [];
        landedScreensSet = [];
    }

    public static void Reset() {
        seenScreensSet.Clear();
        landedScreensSet.Clear();
    }
    public static void AddSeenScreen(int index) {
        seenScreensSet.Add(index);
    }
    public static void AddLandedScreen(int index) {
        landedScreensSet.Add(index);
        seenScreensSet.Clear();
    }
    public static bool HasSeenScreen(int index) {
        return seenScreensSet.Contains(index);
    }
    public static bool HasLandedScreen(int index) {
        return landedScreensSet.Contains(index);
    }
}