using System.Windows.Markup;
using JumpKing.PauseMenu.BT.Actions;

namespace AutoSplitterWS.Menu;
public class ToggleScreenNumber : ITextToggle
{
    public ToggleScreenNumber() : base(AutoSplitterWS.Prefs.IsShowScreenNumber)
    {
    }

    protected override string GetName() => "Show Current Screen#";

    protected override void OnToggle()
    {
        AutoSplitterWS.Prefs.IsShowScreenNumber = toggle;
    }
}
