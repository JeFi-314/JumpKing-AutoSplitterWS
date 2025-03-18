using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using LiveSplit.JumpKingWS.Split;

namespace LiveSplit.JumpKingWS.UI.Split;
public partial class ScreenSplitSetting : SplitSetting
{
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

        toolTip.SetToolTip(numericUpDown_Number, "Screen Number");
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
