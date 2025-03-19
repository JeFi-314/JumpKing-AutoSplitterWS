using System.Globalization;
using System.Reflection.Emit;
using System.Windows.Markup;
using HarmonyLib;
using JumpKing.PauseMenu.BT;
using JumpKing.PauseMenu.BT.Actions;
using JumpKing.Workshop.Nodes;
using Microsoft.Xna.Framework;

namespace AutoSplitterWS.Menu;
public class TextConnectionState : JumpKing.PauseMenu.BT.TextInfo
{
    public static TextConnectionState Instance {get; private set;}

    static TextConnectionState()
    {
        Instance = new TextConnectionState();
    }

    private TextConnectionState() : base("Connecting", Color.White) {}

    public static void SetState(bool connected)
    {
        var text = Traverse.Create(Instance).Field<string>("m_text");
        var color = Traverse.Create(Instance).Field<Color>("m_color");
        if (connected) {
            text.Value = "Connected";
            color.Value = Color.Lime;
        } else {
            text.Value = "Disconnected";
            color.Value = Color.Crimson;
        }
    }
}
