using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CommonCom;
using LiveSplit.JumpKingWS.Split;

namespace LiveSplit.JumpKingWS.UI.Split;
public partial class EndingSplitSetting : SplitSetting
{
    private EndingSplit endingSplit;
    public override SplitBase Split => endingSplit;

    public EndingSplitSetting(EndingSplit split)
    {
        InitializeComponent();

        endingSplit = split;
        SetupControlValues();
        AddHandlers();
    }

    protected override void SetupControlValues()
    {
    }
    protected override void AddHandlers() 
    {
    }
    protected override void RemoveHandlers() 
    {
    }
    private void Changed(object sender, EventArgs e)
    {
    }
}
