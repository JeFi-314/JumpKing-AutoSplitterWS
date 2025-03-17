using System.Windows.Forms;

namespace LiveSplit.JumpKingWS.UI;
partial class Settings
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        foreach (var frame in SplitSettingFrames) {
            frame.Dispose();
        }
        SplitSettingFrames.Clear();
        flow_SplitSettings.Controls.Clear();

        if (isRegistedFormClosed) {
            Form form = FindForm();
            form.FormClosed -= OnMainFormClosed;
            isRegistedFormClosed = false;
        }

        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.flow_Upper = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox_AutoStart = new System.Windows.Forms.CheckBox();
            this.checkBox_AutoReset = new System.Windows.Forms.CheckBox();
            this.checkBox_Undo = new System.Windows.Forms.CheckBox();
            this.flow_SplitSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.flow_Upper.SuspendLayout();
            this.SuspendLayout();
            // 
            // flow_Upper
            // 
            this.flow_Upper.Controls.Add(this.checkBox_AutoStart);
            this.flow_Upper.Controls.Add(this.checkBox_AutoReset);
            this.flow_Upper.Controls.Add(this.checkBox_Undo);
            this.flow_Upper.Dock = System.Windows.Forms.DockStyle.Top;
            this.flow_Upper.Location = new System.Drawing.Point(3, 3);
            this.flow_Upper.Name = "flow_Upper";
            this.flow_Upper.Size = new System.Drawing.Size(474, 30);
            this.flow_Upper.TabIndex = 0;
            // 
            // checkBox_AutoStart
            // 
            this.checkBox_AutoStart.AutoSize = true;
            this.checkBox_AutoStart.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.checkBox_AutoStart.Location = new System.Drawing.Point(3, 3);
            this.checkBox_AutoStart.Name = "checkBox_AutoStart";
            this.checkBox_AutoStart.Size = new System.Drawing.Size(112, 18);
            this.checkBox_AutoStart.TabIndex = 0;
            this.checkBox_AutoStart.Text = "Auto Start Split";
            this.checkBox_AutoStart.UseVisualStyleBackColor = true;
            // 
            // checkBox_AutoReset
            // 
            this.checkBox_AutoReset.AutoSize = true;
            this.checkBox_AutoReset.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.checkBox_AutoReset.Location = new System.Drawing.Point(121, 3);
            this.checkBox_AutoReset.Name = "checkBox_AutoReset";
            this.checkBox_AutoReset.Size = new System.Drawing.Size(117, 18);
            this.checkBox_AutoReset.TabIndex = 1;
            this.checkBox_AutoReset.Text = "Auto Reset Split";
            this.checkBox_AutoReset.UseVisualStyleBackColor = true;
            // 
            // checkBox_Undo
            // 
            this.checkBox_Undo.AutoSize = true;
            this.checkBox_Undo.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.checkBox_Undo.Location = new System.Drawing.Point(244, 3);
            this.checkBox_Undo.Name = "checkBox_Undo";
            this.checkBox_Undo.Size = new System.Drawing.Size(86, 18);
            this.checkBox_Undo.TabIndex = 2;
            this.checkBox_Undo.Text = "Undo Split";
            this.checkBox_Undo.UseVisualStyleBackColor = true;
            // 
            // flow_SplitSettings
            // 
            this.flow_SplitSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_SplitSettings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flow_SplitSettings.Location = new System.Drawing.Point(3, 33);
            this.flow_SplitSettings.Name = "flow_SplitSettings";
            this.flow_SplitSettings.Size = new System.Drawing.Size(474, 434);
            this.flow_SplitSettings.TabIndex = 1;
            // 
            // toolTip
            // 
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip_Popup);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.flow_SplitSettings);
            this.Controls.Add(this.flow_Upper);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(450, 470);
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "Settings";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(480, 470);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.flow_Upper.ResumeLayout(false);
            this.flow_Upper.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel flow_Upper;
    private System.Windows.Forms.FlowLayoutPanel flow_SplitSettings;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.CheckBox checkBox_AutoStart;
    private System.Windows.Forms.CheckBox checkBox_AutoReset;
    private System.Windows.Forms.CheckBox checkBox_Undo;
}
