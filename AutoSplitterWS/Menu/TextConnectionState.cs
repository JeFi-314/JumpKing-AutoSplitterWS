using HarmonyLib;
using JumpKing;
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

    private TextConnectionState() : base("Connecting", Color.Yellow) {}

    public static void SetState(ConnectionState connected)
    {
        var text = Traverse.Create(Instance).Field<string>("m_text");
        var color = Traverse.Create(Instance).Field<Color>("m_color");
        switch (connected) {
            case ConnectionState.Connecting:
                text.Value = "Connecting";
                color.Value = Color.Yellow;
                break;
            case ConnectionState.Connected:
                text.Value = "Connected";
                color.Value = Color.Lime;
                break;
            case ConnectionState.Disconnected:
                text.Value = "Disconnected";
                color.Value = Color.Crimson;
                break;
        }
    }
}
