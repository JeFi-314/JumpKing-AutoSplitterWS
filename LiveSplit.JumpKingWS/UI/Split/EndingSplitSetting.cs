using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CommonCom;
using CommonCom.Util;
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
        combo_Ending.DataSource = Enum.GetValues(typeof(Ending));
        combo_Ending.Format += (s, e) =>
        {
            if (e.ListItem is Ending item)
            {
                e.Value = item.GetName();
            }
        };

        combo_Ending.SelectedItem = endingSplit.Ending;
    }
    protected override void AddHandlers() 
    {
        combo_Ending.SelectedIndexChanged += OnEndingChanged;
    }
    protected override void RemoveHandlers() 
    {
        combo_Ending.SelectedIndexChanged -= OnEndingChanged;
    }
    private void OnEndingChanged(object sender, EventArgs e)
    {
        endingSplit.Ending = (Ending)combo_Ending.SelectedItem;
    }
}
