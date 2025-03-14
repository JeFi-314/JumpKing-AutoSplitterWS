using System.ComponentModel;

namespace LiveSplit.JumpKingWS.Split;

public enum SplitType
{
    [Description("Manual|")]
    Manual,
    [Description("Screen|")]
    Screen,
    [Description("Item|")]
    Item,
    [Description("Raven|")]
    Raven,
    [Description("Achievement|")]
    Achievement,
    [Description("Ending|")]
    Ending,
}