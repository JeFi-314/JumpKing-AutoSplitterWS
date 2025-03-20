using System.Globalization;
using System.Reflection.Emit;
using System.Windows.Markup;
using HarmonyLib;
using JumpKing;
using JumpKing.PauseMenu.BT;
using JumpKing.PauseMenu.BT.Actions;
using JumpKing.Workshop.Nodes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AutoSplitterWS.Menu;
public class TextConnectionState : JumpKing.PauseMenu.BT.TextInfo
{
    private static TextConnectionState instance; 
    public static TextConnectionState Instance
    {
        // need to update SpriteFont bc content manager will
        // reload assets (including font) everytime you change the map
        get
        {
            var font = Traverse.Create(instance).Field<SpriteFont>("m_font");
            font.Value = Game1.instance.contentManager.font.MenuFont;
            return instance;
        }
    }

    static TextConnectionState()
    {
        instance = new TextConnectionState();
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
