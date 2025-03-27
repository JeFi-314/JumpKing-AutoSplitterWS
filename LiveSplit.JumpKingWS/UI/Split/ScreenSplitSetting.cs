using System;
using LiveSplit.JumpKingWS.Split;

namespace LiveSplit.JumpKingWS.UI.Split;
public partial class ScreenSplitSetting : SplitSetting
{
    const string numericUpDown_Number_TIP = "Screen Number";
    private ScreenSplit screenSplit;
    public override SplitBase Split => screenSplit;

    public ScreenSplitSetting(ScreenSplit split)
    {
        InitializeComponent();

        screenSplit = split;
        SetupControlValues();
        AddHandlers();
    }

    protected override void SetupControlValues()
    {
        numericUpDown_Number.Value = screenSplit.Number;

        toolTip.SetToolTip(numericUpDown_Number, numericUpDown_Number_TIP);
    }
    protected override void AddHandlers() 
    {
        numericUpDown_Number.ValueChanged += new EventHandler(OnNumberChanged);
    }
    protected override void RemoveHandlers() 
    {
        numericUpDown_Number.ValueChanged -= OnNumberChanged;
    }

    private void OnNumberChanged(object sender, EventArgs e)
    {
        screenSplit.Number = (int)numericUpDown_Number.Value;
    }
}
