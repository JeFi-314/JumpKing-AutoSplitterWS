namespace LiveSplit.JumpKingWS.UI
{
    partial class SplitSettingFrame
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
            this.table_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label_SplitName = new System.Windows.Forms.Label();
            this.combo_SplitType = new System.Windows.Forms.ComboBox();
            this.table_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_Main
            // 
            this.table_Main.ColumnCount = 4;
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.table_Main.Controls.Add(this.label_SplitName, 0, 0);
            this.table_Main.Controls.Add(this.combo_SplitType, 1, 0);
            this.table_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_Main.Location = new System.Drawing.Point(2, 2);
            this.table_Main.Margin = new System.Windows.Forms.Padding(0);
            this.table_Main.Name = "table_Main";
            this.table_Main.RowCount = 1;
            this.table_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.Size = new System.Drawing.Size(456, 22);
            this.table_Main.TabIndex = 0;
            // 
            // label_SplitName
            // 
            this.label_SplitName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SplitName.Location = new System.Drawing.Point(0, 0);
            this.label_SplitName.Margin = new System.Windows.Forms.Padding(0);
            this.label_SplitName.Name = "label_SplitName";
            this.label_SplitName.Size = new System.Drawing.Size(100, 22);
            this.label_SplitName.TabIndex = 0;
            this.label_SplitName.Text = "split name";
            this.label_SplitName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combo_SplitType
            // 
            this.combo_SplitType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_SplitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_SplitType.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.combo_SplitType.FormattingEnabled = true;
            this.combo_SplitType.Location = new System.Drawing.Point(100, 0);
            this.combo_SplitType.Margin = new System.Windows.Forms.Padding(0);
            this.combo_SplitType.Name = "combo_SplitType";
            this.combo_SplitType.Size = new System.Drawing.Size(70, 21);
            this.combo_SplitType.TabIndex = 4;
            // 
            // SplitSettingFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table_Main);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SplitSettingFrame";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(460, 26);
            this.table_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_Main;
        private System.Windows.Forms.Label label_SplitName;
        private System.Windows.Forms.ComboBox combo_SplitType;
    }
}
