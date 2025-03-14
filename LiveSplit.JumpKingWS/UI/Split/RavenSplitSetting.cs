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
        textBox_RavenName.Text = ravenSplit.ravenName;
        numericUpDown_HomeIndex.Value = ravenSplit.homeIndex1;
    }
    protected override void AddHandlers() 
    {
        textBox_RavenName.TextChanged += OnRavenNameChanged;
        numericUpDown_HomeIndex.ValueChanged += OnHomeIndexChanged;
    }
    protected override void RemoveHandlers() 
    {
        textBox_RavenName.TextChanged -= OnRavenNameChanged;
        numericUpDown_HomeIndex.ValueChanged -= OnHomeIndexChanged;
    }

    private void OnRavenNameChanged(object sender, EventArgs e)
    {
        ravenSplit.ravenName = textBox_RavenName.Text;
    }
    private void OnHomeIndexChanged(object sender, EventArgs e)
    {
        ravenSplit.homeIndex1 = (int)numericUpDown_HomeIndex.Value;
    }

}
