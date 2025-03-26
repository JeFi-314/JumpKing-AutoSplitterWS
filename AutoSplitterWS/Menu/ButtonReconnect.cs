using AutoSplitterWS.Node;
using JumpKing.PauseMenu.BT;

namespace AutoSplitterWS.Menu;
public class ButtonReconnect : TextButton
{
    public ButtonReconnect() : base("Reconnect", new ConnectNode()) {}
}
