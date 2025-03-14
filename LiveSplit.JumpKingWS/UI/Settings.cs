using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveSplit.JumpKingWS.Split;

namespace LiveSplit.JumpKingWS.UI;
public partial class Settings : UserControl
{
    private bool isRegistedFormClosed = false;
    private readonly List<SplitSettingFrame> SplitSettingFrames = [];

    public Settings()
    {
        InitializeComponent();
    }

    private void Settings_Load(object sender, EventArgs e)
    {
        Form form = FindForm();
        if (!isRegistedFormClosed) {
            form.FormClosed += OnMainFormClosed;
            isRegistedFormClosed = true;
        }

        flow_SplitSettings.SuspendLayout();
        for (int i = 0; i<Component.Run.Count; i++) {
            var segment = Component.Run[i];
            Debug.WriteLine($"[Setting] Add setting for split {segment.Name}");
            var frame = i<SplitManager.SplitList.Count
                ? new SplitSettingFrame(segment.Name, SplitManager.SplitList[i])
                : new SplitSettingFrame(segment.Name);
            flow_SplitSettings.Controls.Add(frame);
            SplitSettingFrames.Add(frame);
        }
        flow_SplitSettings.ResumeLayout();
    }

    private void OnMainFormClosed(object sender, FormClosedEventArgs e)
    {
        Form form = FindForm();

        if (form.DialogResult == DialogResult.OK) {
            SplitManager.Clear();
            SplitManager.AddSplits(SplitSettingFrames.Select(frame => frame.SplitSetting.Split));
        }
        
        foreach (var frame in SplitSettingFrames) {
            frame.Dispose();
        }
        SplitSettingFrames.Clear();
        flow_SplitSettings.Controls.Clear();
        Debug.WriteLine($"[Setting] Clear all split settings");

        if (isRegistedFormClosed) {
            form.FormClosed -= OnMainFormClosed;
            isRegistedFormClosed = false;
        }
    }

    private void toolTip_Popup(object sender, PopupEventArgs e)
    {

    }
}
