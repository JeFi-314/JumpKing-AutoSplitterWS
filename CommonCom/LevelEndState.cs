using System.ComponentModel;

namespace CommonCom;

public enum LevelEndState: byte {
    None = 0x00,
    [Description("Win|Reach any babe.")]
    Win = 0x01,
    [Description("Restart|Restart game by hotkey or pause menu.")]
    Restart = 0x02,
    [Description("Exit to Menu|Select \"Exit to Menu\" in pause menu.")]
    Exit2Menu = 0x03,
}