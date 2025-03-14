﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonCom.Util;
using LiveSplit.JumpKingWS.Split;
using LiveSplit.JumpKingWS.UI.Split;

namespace LiveSplit.JumpKingWS.UI;
public partial class SplitSettingFrame : UserControl
{
    public SplitSetting SplitSetting {get; private set;} = null;
    public SplitSettingFrame(string splitName, SplitBase split = null)
    {
        InitializeComponent();

        split ??= new ManualSplit();
        SetupControls(splitName, split);
        AddHandlers();
    }

    private void SetupControls(string splitName, SplitBase split)
    {
        table_Main.SuspendLayout();
        label_SplitName.Text = splitName;

        combo_SplitType.DataSource = Enum.GetValues(typeof(SplitType));
        combo_SplitType.Format += (s, e) =>
        {
            if (e.ListItem is SplitType item)
            {
                e.Value = item.GetName();
            }
        };
        combo_SplitType.SelectedItem = split.SplitType;

        SplitSetting = split.SplitType switch
        {
            SplitType.Manual => new ManualSplitSetting(split.Clone<ManualSplit>()),
            SplitType.Screen => new ScreenSplitSetting(split.Clone<ScreenSplit>()),
            SplitType.Item => new ItemSplitSetting(split.Clone<ItemSplit>()),
            SplitType.Raven => new RavenSplitSetting(split.Clone<RavenSplit>()),
            SplitType.Achievement => new AchievementSplitSetting(split.Clone<AchievementSplit>()),
            SplitType.Ending => new EndingSplitSetting(split.Clone<EndingSplit>()),
            _ => new ManualSplitSetting(new ManualSplit()),
        };
        AddSplitSetting();
        table_Main.ResumeLayout();
    }
    private void AddHandlers()
    {
        combo_SplitType.SelectedIndexChanged += SplitTypeChanged;
    }

    private void SplitTypeChanged(object sender, EventArgs e)
    {
        table_Main.SuspendLayout();
        if (SplitSetting!=null) {
            RemoveSplitSetting();
        }
        SplitType type = (SplitType)combo_SplitType.SelectedItem;
        SplitSetting = type switch
        {
            SplitType.Manual => new ManualSplitSetting(new ManualSplit()),
            SplitType.Screen => new ScreenSplitSetting(new ScreenSplit()),
            SplitType.Item => new ItemSplitSetting(new ItemSplit()),
            SplitType.Raven => new RavenSplitSetting(new RavenSplit()),
            SplitType.Achievement => new AchievementSplitSetting(new AchievementSplit()),
            SplitType.Ending => new EndingSplitSetting(new EndingSplit()),
            _ => new ManualSplitSetting(new ManualSplit()),
        };
        AddSplitSetting();
        table_Main.ResumeLayout();
    }

    private void AddSplitSetting() 
    {
        table_Main.Controls.Add(SplitSetting, 2, 0);
        SplitSetting.Margin = new Padding(0);
        SplitSetting.Dock = DockStyle.Fill;
    }
    private void RemoveSplitSetting()
    {
        table_Main.Controls.Remove(SplitSetting);
        SplitSetting.Dispose();
        SplitSetting = null;
    }
}