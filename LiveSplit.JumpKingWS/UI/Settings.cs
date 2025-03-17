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
using System.Xml;
using LiveSplit.JumpKingWS.Split;

namespace LiveSplit.JumpKingWS.UI;
public partial class Settings : UserControl
{
    public static bool isAutoStartSplit = false;
    public static bool isAutoResetSplit = false;
    public static bool isUndoSplit = false;

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

        checkBox_AutoStart.Checked = isAutoStartSplit;
        checkBox_AutoReset.Checked = isAutoResetSplit;
        checkBox_Undo.Checked = isUndoSplit;

        flow_SplitSettings.SuspendLayout();
        for (int i = 0; i<Component.Run.Count; i++) {
            var segment = Component.Run[i];
            var split = (0<=i & i<SplitManager.SplitList.Count) 
                ? SplitManager.SplitList[i]
                : null;
            Debug.WriteLine($"[UI] Add split setting: {segment.Name} | {split?.FullName}");
            var frame =  new SplitSettingFrame(segment.Name, split);
            flow_SplitSettings.Controls.Add(frame);
            SplitSettingFrames.Add(frame);
        }
        flow_SplitSettings.ResumeLayout();
    }
    public static void LoadFromXml(XmlNode node)
    {
        bool.TryParse(node[nameof(isAutoStartSplit)]?.InnerText, out isAutoStartSplit);
		bool.TryParse(node[nameof(isAutoResetSplit)]?.InnerText, out isAutoResetSplit);
		bool.TryParse(node[nameof(isAutoStartSplit)]?.InnerText, out isUndoSplit);
    }
    public static void SaveToXml(XmlDocument doc, XmlElement ele)
    {
		ele.AppendChild(GetXmlKeyValue(doc, nameof(isAutoStartSplit), isAutoStartSplit));
		ele.AppendChild(GetXmlKeyValue(doc, nameof(isAutoResetSplit), isAutoResetSplit));
		ele.AppendChild(GetXmlKeyValue(doc, nameof(isUndoSplit), isUndoSplit));
    }
    private static XmlElement GetXmlKeyValue<T>(XmlDocument document, string key, T value)
	{
		var element = document.CreateElement(key);
		element.InnerText = value.ToString();
		return element; 
	}

    private void OnMainFormClosed(object sender, FormClosedEventArgs e)
    {
        Form form = FindForm();

        if (form.DialogResult == DialogResult.OK) {
            isAutoStartSplit = checkBox_AutoStart.Checked;
            isAutoResetSplit = checkBox_AutoReset.Checked;
            isUndoSplit = checkBox_Undo.Checked;

            SplitManager.Clear();
            SplitManager.AddSplits(SplitSettingFrames.Select(frame => frame.SplitSetting.Split));
        }
        
        foreach (var frame in SplitSettingFrames) {
            frame.Dispose();
        }
        SplitSettingFrames.Clear();
        flow_SplitSettings.Controls.Clear();
        Debug.WriteLine($"[UI] Clear all split settings");

        if (isRegistedFormClosed) {
            form.FormClosed -= OnMainFormClosed;
            isRegistedFormClosed = false;
        }
    }

    private void toolTip_Popup(object sender, PopupEventArgs e)
    {

    }
}
