using CommonCom;
using CommonCom.Util;

namespace LiveSplit.JumpKingWS.State;
public static class EndingState
{
    private static string lastEndingName;
    static EndingState() {
        lastEndingName = "";
    }

    public static void Reset() {
        lastEndingName = "";
    }

    public static void SetEnding(Ending ending) {
        SetEnding(ending.GetName());
    }
    public static void SetEnding(string endingName) {
        lastEndingName = endingName;
    }

    public static bool CheckEnding(string endingName) {
        return (lastEndingName!=string.Empty) && (endingName==lastEndingName);
    }
}