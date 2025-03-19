using HarmonyLib;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

using JumpKing.Mods;
using AutoSplitterWS.Communication;
using JumpKing;
using JumpKing.GameManager.MultiEnding;
using JumpKing.PauseMenu;

using AutoSplitterWS.Menu;

namespace AutoSplitterWS;
[JumpKingMod(IDENTIFIER)]
public static class AutoSplitterWS
{
    const string IDENTIFIER = "JeFi.AutoSplitterWS";
    const string HARMONY_IDENTIFIER = "JeFi.AutoSplitterWS.Harmony";
    const string SETTINGS_FILE = "JeFi.AutoSplitterWS.Preferences.xml";

    public static string AssemblyPath { get; set; }
    public static Preferences Prefs { get; private set; }
    public static bool isWin = false;
    public static EndingType Ending = EndingType.Normal;

    [BeforeLevelLoad]
    public static void BeforeLevelLoad()
    {
        AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#if DEBUG
        // Debugger.Launch();
        // Debug.WriteLine("------");
        // Harmony.DEBUG = true;
        // Environment.SetEnvironmentVariable("HARMONY_LOG_FILE", $@"{AssemblyPath}\harmony.log.txt");
#endif
        try
        {
            Prefs = XmlSerializerHelper.Deserialize<Preferences>($@"{AssemblyPath}\{SETTINGS_FILE}");
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[ERROR] [{IDENTIFIER}] {e.Message}");
            Prefs = new Preferences();
        }

        CommunicationWrapper.Start();

        Harmony harmony = new Harmony(HARMONY_IDENTIFIER);

        try {
            new Patching.AchievementRegister(harmony);
            new Patching.CameraFollowComp(harmony);
            new Patching.EndingManager(harmony);
            new Patching.GameLoop(harmony);
            new Patching.InventoryManager(harmony);
            new Patching.JumpGame(harmony);
            new Patching.OnGiveUpAch(harmony);
            new Patching.RavenFlee(harmony);
        }
        catch (Exception e) {
            Debug.WriteLine(e.ToString());

            // Debug.WriteLine($"Message: {e.Message}");
            // Debug.WriteLine($"Stack Trace: {e.StackTrace}");

            // if (e.InnerException != null)
            // {
            //         Debug.WriteLine("Inner Exception:");
            //         Debug.WriteLine(e.InnerException.ToString());
            // }
        }

#if DEBUG
        Environment.SetEnvironmentVariable("HARMONY_LOG_FILE", null);
#endif
    }

    [OnLevelStart]
    public static void OnLevelStart()
    {
        Patching.CameraFollowComp.Reset();
    }

    [OnLevelEnd]
    public static void OnLevelEnd()
    {
        if (isWin)
            CommunicationWrapper.SendWin((int) Ending);
        else if (Game1.instance.m_game.m_restart_state) 
            CommunicationWrapper.SendRestart();
        else
            CommunicationWrapper.SendExitToMenu();
        isWin = false;
        Ending = EndingType.Normal;
    }

    #region Menu Items
    [PauseMenuItemSetting]
    [MainMenuItemSetting]
    public static ToggleScreenNumber ToggleScreenNumber(object factory, GuiFormat format)
    {
        return new ToggleScreenNumber();
    }
    #endregion
}
