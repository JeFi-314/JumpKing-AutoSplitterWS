using System.Windows.Markup;
using AutoSplitterWS.Node;
using JumpKing.PauseMenu.BT;
using JumpKing.PauseMenu.BT.Actions;

namespace AutoSplitterWS.Menu;
public class ButtonReconnect : TextButton
{
    public ButtonReconnect() : base("Reconnect to LiveSplit", new ConnectNode()) {}
}
