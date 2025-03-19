using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.JumpKingWS.Split;

namespace LiveSplit.JumpKingWS.UI.Split;
public partial class RavenSplitSetting : SplitSetting
{
    private RavenSplit ravenSplit;
    public override SplitBase Split => ravenSplit;

    public RavenSplitSetting(RavenSplit split)
    {
        InitializeComponent();

        ravenSplit = split;
        SetupControlValues();
        AddHandlers();
    }
    protected override void SetupControlValues()
    {
        combo_RavenName.Items.AddRange(["raven", "white_raven", "tsuchinoko", "fly"]);
        combo_RavenName.Text = ravenSplit.RavenName;

        numericUpDown_HomeIndex.Value = ravenSplit.HomeIndex1;

        toolTip.SetToolTip(combo_RavenName, "Raven Name \n(drop-down options are original game raven name)");
        toolTip.SetToolTip(numericUpDown_HomeIndex, "Home Number (one-index)");
    }
    protected override void AddHandlers() 
    {
        combo_RavenName.TextChanged += OnRavenNameChanged;
        numericUpDown_HomeIndex.ValueChanged += OnHomeIndexChanged;
        combo_RavenName.Resize += OnComboBoxResize;
    }
    protected override void RemoveHandlers() 
    {
        combo_RavenName.TextChanged -= OnRavenNameChanged;
        numericUpDown_HomeIndex.ValueChanged -= OnHomeIndexChanged;
        combo_RavenName.Resize -= OnComboBoxResize;
    }

    private void OnRavenNameChanged(object sender, EventArgs e)
    {
        ravenSplit.RavenName = combo_RavenName.Text;
    }
    private void OnHomeIndexChanged(object sender, EventArgs e)
    {
        ravenSplit.HomeIndex1 = (int)numericUpDown_HomeIndex.Value;
    }

    // Taken from https://stackoverflow.com/questions/25901015
    // avoid combobox text get highlight after init
    private void OnComboBoxResize(object sender, EventArgs e)
    {
        var box = (ComboBox)sender;
        if (!box.IsHandleCreated)
            return;  // avoid possible exception

        box.BeginInvoke(new Action(() => box.SelectionLength = 0));
    }
}
