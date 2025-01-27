using JumpKing.PauseMenu.BT.Actions;

namespace AutoSplitter.Menu;
public class OptionUpsideDown : IOptions
{
    public OptionUpsideDown() : base(3, (int), EdgeMode.Wrap)
    {
    }

    protected override bool CanChange()
    {
        return true;
    }

    protected override string CurrentOptionName()
    {
    }

    protected override void OnOptionChange(int option)
    {
    }

}
