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
            this.table_Upper = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_AutoStart = new System.Windows.Forms.CheckBox();
            this.checkBox_AutoReset = new System.Windows.Forms.CheckBox();
            this.checkBox_Undo = new System.Windows.Forms.CheckBox();
            this.button_Reconnect = new System.Windows.Forms.Button();
            this.flow_SplitSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.table_Upper.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_Upper
            // 
            this.table_Upper.ColumnCount = 5;
            this.table_Upper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table_Upper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table_Upper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table_Upper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Upper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.table_Upper.Controls.Add(this.checkBox_AutoStart);
            this.table_Upper.Controls.Add(this.checkBox_AutoReset);
            this.table_Upper.Controls.Add(this.checkBox_Undo);
            this.table_Upper.Controls.Add(this.button_Reconnect, 4, 0);
            this.table_Upper.Dock = System.Windows.Forms.DockStyle.Top;
            this.table_Upper.Location = new System.Drawing.Point(3, 3);
            this.table_Upper.Name = "table_Upper";
            this.table_Upper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.table_Upper.Size = new System.Drawing.Size(474, 30);
            this.table_Upper.TabIndex = 0;
            // 
            // checkBox_AutoStart
            // 
            this.checkBox_AutoStart.AutoSize = true;
            this.checkBox_AutoStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_AutoStart.Font = new System.Drawing.Font("PMingLiU", 9F);
            this.checkBox_AutoStart.Location = new System.Drawing.Point(3, 3);
            this.checkBox_AutoStart.Name = "checkBox_AutoStart";
            this.checkBox_AutoStart.Size = new System.Drawing.Size(95, 24);
            this.checkBox_AutoStart.TabIndex = 0;
            this.checkBox_AutoStart.Text = "Auto Start Split";
            this.checkBox_AutoStart.UseVisualStyleBackColor = true;
            // 
            // checkBox_AutoReset
            // 
            this.checkBox_AutoReset.AutoSize = true;
            this.checkBox_AutoReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_AutoReset.Font = new System.Drawing.Font("PMingLiU", 9F);
            this.checkBox_AutoReset.Location = new System.Drawing.Point(104, 3);
            this.checkBox_AutoReset.Name = "checkBox_AutoReset";
            this.checkBox_AutoReset.Size = new System.Drawing.Size(99, 24);
            this.checkBox_AutoReset.TabIndex = 1;
            this.checkBox_AutoReset.Text = "Auto Reset Split";
            this.checkBox_AutoReset.UseVisualStyleBackColor = true;
            // 
            // checkBox_Undo
            // 
            this.checkBox_Undo.AutoSize = true;
            this.checkBox_Undo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Undo.Font = new System.Drawing.Font("PMingLiU", 9F);
            this.checkBox_Undo.Location = new System.Drawing.Point(209, 3);
            this.checkBox_Undo.Name = "checkBox_Undo";
            this.checkBox_Undo.Size = new System.Drawing.Size(74, 24);
            this.checkBox_Undo.TabIndex = 2;
            this.checkBox_Undo.Text = "Undo Split";
            this.checkBox_Undo.UseVisualStyleBackColor = true;
            // 
            // button_Connect
            // 
            this.button_Reconnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Reconnect.Location = new System.Drawing.Point(397, 3);
            this.button_Reconnect.Name = "button_Reconnect";
            this.button_Reconnect.Size = new System.Drawing.Size(74, 24);
            this.button_Reconnect.TabIndex = 3;
            this.button_Reconnect.Text = "Reconnect";
            this.button_Reconnect.UseVisualStyleBackColor = true;
            this.button_Reconnect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // flow_SplitSettings
            // 
            this.flow_SplitSettings.AllowDrop = true;
            this.flow_SplitSettings.AutoScroll = true;
            this.flow_SplitSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_SplitSettings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flow_SplitSettings.Location = new System.Drawing.Point(3, 33);
            this.flow_SplitSettings.Name = "flow_SplitSettings";
            this.flow_SplitSettings.Size = new System.Drawing.Size(474, 434);
            this.flow_SplitSettings.TabIndex = 1;
            this.flow_SplitSettings.WrapContents = false;
            this.flow_SplitSettings.DragEnter += new System.Windows.Forms.DragEventHandler(this.flow_SplitSettings_DragEnter);
            this.flow_SplitSettings.DragOver += new System.Windows.Forms.DragEventHandler(this.flow_SplitSettings_DragOver);
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
            this.Controls.Add(this.table_Upper);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(480, 470);
            this.MinimumSize = new System.Drawing.Size(450, 400);
            this.Name = "Settings";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(480, 470);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.table_Upper.ResumeLayout(false);
            this.table_Upper.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel table_Upper;
    private System.Windows.Forms.FlowLayoutPanel flow_SplitSettings;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.CheckBox checkBox_AutoStart;
    private System.Windows.Forms.CheckBox checkBox_AutoReset;
    private System.Windows.Forms.CheckBox checkBox_Undo;
    private System.Windows.Forms.Button button_Reconnect;
}
