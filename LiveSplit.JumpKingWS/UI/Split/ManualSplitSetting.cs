using LiveSplit.JumpKingWS.Split;

namespace LiveSplit.JumpKingWS.UI.Split;
public partial class ManualSplitSetting : SplitSetting
{
    private ManualSplit manualSplit;
    public override SplitBase Split => manualSplit;

    public ManualSplitSetting(ManualSplit split)
    {
        InitializeComponent();

        manualSplit = split;
        SetupControlValues();
        AddHandlers();
    }
    protected override void SetupControlValues() {}
    protected override void AddHandlers() {}
    protected override void RemoveHandlers() {}
}
