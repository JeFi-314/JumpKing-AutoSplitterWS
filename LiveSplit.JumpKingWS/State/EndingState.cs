using CommonCom;
using CommonCom.Util;

namespace LiveSplit.JumpKingWS.State;
public static class EndingState
{
    private static Ending? lastEnding;
    static EndingState() {
        lastEnding = null;
    }

    public static void Reset() {
        lastEnding = null;
    }

    public static void SetEnding(Ending ending) {
        lastEnding = ending;
    }

    public static bool CheckEnding(Ending ending) {
        return (lastEnding!=null) && (ending==lastEnding);
    }
}