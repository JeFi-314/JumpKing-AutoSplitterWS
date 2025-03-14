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
        numericUpDown_Number.Value = screenSplit.number;
    }
    protected override void AddHandlers() 
    {
        numericUpDown_Number.ValueChanged += new EventHandler(NumberChanged);
    }
    protected override void RemoveHandlers() 
    {
        numericUpDown_Number.ValueChanged -= NumberChanged;
    }

    private void NumberChanged(object sender, EventArgs e)
    {
        screenSplit.number = (int)numericUpDown_Number.Value;
    }
}
