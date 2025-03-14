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
            form.FormClosed -= MainFormClosed;
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.flow_SplitSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.flow_Upper.SuspendLayout();
            this.SuspendLayout();
            // 
            // flow_Upper
            // 
            this.flow_Upper.Controls.Add(this.checkBox1);
            this.flow_Upper.Controls.Add(this.checkBox2);
            this.flow_Upper.Controls.Add(this.checkBox3);
            this.flow_Upper.Dock = System.Windows.Forms.DockStyle.Top;
            this.flow_Upper.Location = new System.Drawing.Point(3, 3);
            this.flow_Upper.Name = "flow_Upper";
            this.flow_Upper.Size = new System.Drawing.Size(474, 30);
            this.flow_Upper.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(77, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(86, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(77, 16);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(169, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(77, 16);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
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
            this.Size = new System.Drawing.Size(470, 470);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.flow_Upper.ResumeLayout(false);
            this.flow_Upper.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel flow_Upper;
    private System.Windows.Forms.FlowLayoutPanel flow_SplitSettings;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.CheckBox checkBox3;
}
