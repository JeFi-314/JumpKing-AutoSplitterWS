using System;
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
    private bool isReadyForDrag = false;
    private int mouseY = 0;
    public SplitType lastSplitType {get; private set;} = SplitType.Manual;
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
        lastSplitType = split.SplitType;

        SplitSetting setting = split.SplitType switch
        {
            SplitType.Manual => new ManualSplitSetting(split.Clone<ManualSplit>()),
            SplitType.Screen => new ScreenSplitSetting(split.Clone<ScreenSplit>()),
            SplitType.Item => new ItemSplitSetting(split.Clone<ItemSplit>()),
            SplitType.Raven => new RavenSplitSetting(split.Clone<RavenSplit>()),
            SplitType.Achievement => new AchievementSplitSetting(split.Clone<AchievementSplit>()),
            SplitType.Ending => new EndingSplitSetting(split.Clone<EndingSplit>()),
            _ => new ManualSplitSetting(new ManualSplit()),
        };
        AddSplitSetting(setting);

        toolTip.SetToolTip(label_SplitName, "Split Name");
        toolTip.SetToolTip(combo_SplitType, "Split Type");
        toolTip.SetToolTip(pictureBox_Drag, "Drag & Drop");
        table_Main.ResumeLayout();
    }
    private void AddHandlers()
    {
        combo_SplitType.SelectedIndexChanged += OnSplitTypeChanged;
    }

    private void OnSplitTypeChanged(object sender, EventArgs e)
    {
        SplitType type = (SplitType)combo_SplitType.SelectedItem;
        if (lastSplitType == type) return;
        lastSplitType = type;

        table_Main.SuspendLayout();
        if (SplitSetting!=null) RemoveSplitSetting();
        SplitSetting setting = type switch
        {
            SplitType.Manual => new ManualSplitSetting(new ManualSplit()),
            SplitType.Screen => new ScreenSplitSetting(new ScreenSplit()),
            SplitType.Item => new ItemSplitSetting(new ItemSplit()),
            SplitType.Raven => new RavenSplitSetting(new RavenSplit()),
            SplitType.Achievement => new AchievementSplitSetting(new AchievementSplit()),
            SplitType.Ending => new EndingSplitSetting(new EndingSplit()),
            _ => new ManualSplitSetting(new ManualSplit()),
        };
        AddSplitSetting(setting);
        table_Main.ResumeLayout();
    }

    public void AddSplitSetting(SplitSetting setting) 
    {
        SplitSetting = setting;
        table_Main.Controls.Add(SplitSetting, 2, 0);
        SplitSetting.Margin = new Padding(0);
        SplitSetting.Dock = DockStyle.Fill;
    }
    public void RemoveSplitSetting(bool dispose = true)
    {
        table_Main.Controls.Remove(SplitSetting);
        if (dispose) SplitSetting.Dispose();
        SplitSetting = null;
    }
    public void SetSplitType(SplitType type)
    {
        lastSplitType = type;
        combo_SplitType.SelectedItem = type;
    }

    private void pictureBox_Drag_MouseMove(object sender, MouseEventArgs e)
    {
        if (isReadyForDrag && e.Button == MouseButtons.Left) {
            if (Math.Abs(mouseY - e.Y) > 5) {
                DoDragDrop(new Node<SplitSettingFrame>(this), DragDropEffects.All);
                isReadyForDrag = false;
            }
        }
    }

    private void pictureBox_Drag_MouseDown(object sender, MouseEventArgs e)
    {
        mouseY = e.Y;
        isReadyForDrag = true;
    }
}