namespace CommonCom;

/// Identifiers for messages sent between JumpKing and AutoSplitter.
/// See the send / receive implementations for the attached data.
public enum MessageID : byte {
    None = 0x00,

    #region Common

    /// Sent on a regular interval to keep up the connection
    Ping = 0x01,

    /// Indicates the adapter should completely restart itself
    Reset = 0x02,

    // /// Syncs the game-settings between JumpKing and AutoSplitter
    // GameSettings = 0x03,

    #endregion

    #region JumpKing to AutoSplitter

    SeeScreen = 0x11,

    LandOnScreen = 0x12,

    AddItems = 0x13,

    GetAchievement = 0x14,

    RavenFlee = 0x15,

    UpdateTicks = 0x16,

    GameLoopStart = 0x17,

    Win = 0x18,

    Restart = 0x19,

    ExitToMenu = 0x1A,

    GiveUp = 0x1B,

    LevelDataResponse = 0x1C,


    #endregion

    #region AutoSplitter to JumpKing

    RequestLevelData = 0x22,

    #endregion
}