using System.ComponentModel;

// Copy from JumpKing
// namespace JumpKing.GameManager.MultiEnding;

namespace CommonCom;

public enum Ending
{
    [Description("Main Babe")]
	Normal,
    [Description("New Babe+")]
	NewBabePlus,
    [Description("Ghost of the Babe")]
	Ghost
}
