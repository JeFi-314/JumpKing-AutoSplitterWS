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
public partial class AchievementSplitSetting : SplitSetting
{
    private AchievementSplit achievementSplit;
    public override SplitBase Split => achievementSplit;

    public AchievementSplitSetting(AchievementSplit split)
    {
        InitializeComponent();

        achievementSplit = split;
        SetupControlValues();
        AddHandlers();
    }

    protected override void SetupControlValues()
    {
        comboBox_Achievement.DataSource = Enum.GetValues(typeof(Achievement));
        comboBox_Achievement.Format += (s, e) =>
        {
            if (e.ListItem is Achievement code)
            {
                e.Value = code.GetName();
            }
        };
        comboBox_Achievement.SelectedItem = achievementSplit.Code;
    }
    protected override void AddHandlers() 
    {
        comboBox_Achievement.SelectedIndexChanged += OnCodeChanged;
    }
    protected override void RemoveHandlers() 
    {
        comboBox_Achievement.SelectedIndexChanged -= OnCodeChanged;
    }
    private void OnCodeChanged(object sender, EventArgs e)
    {
        achievementSplit.Code = (Achievement)comboBox_Achievement.SelectedItem;
    }
}
