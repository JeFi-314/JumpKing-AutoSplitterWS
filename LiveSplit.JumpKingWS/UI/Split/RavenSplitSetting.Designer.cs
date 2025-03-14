namespace LiveSplit.JumpKingWS.UI.Split
{
    partial class RavenSplitSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        public override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.table_Main = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown_HomeIndex = new System.Windows.Forms.NumericUpDown();
            this.textBox_RavenName = new System.Windows.Forms.TextBox();
            this.table_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HomeIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // table_Main
            // 
            this.table_Main.ColumnCount = 3;
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.Controls.Add(this.numericUpDown_HomeIndex, 1, 0);
            this.table_Main.Controls.Add(this.textBox_RavenName, 0, 0);
            this.table_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_Main.Location = new System.Drawing.Point(0, 0);
            this.table_Main.Margin = new System.Windows.Forms.Padding(0);
            this.table_Main.Name = "table_Main";
            this.table_Main.RowCount = 1;
            this.table_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.Size = new System.Drawing.Size(200, 22);
            this.table_Main.TabIndex = 0;
            // 
            // numericUpDown_HomeIndex
            // 
            this.numericUpDown_HomeIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_HomeIndex.Font = new System.Drawing.Font("PMingLiU", 9F);
            this.numericUpDown_HomeIndex.Location = new System.Drawing.Point(100, 0);
            this.numericUpDown_HomeIndex.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDown_HomeIndex.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown_HomeIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_HomeIndex.Name = "numericUpDown_HomeIndex";
            this.numericUpDown_HomeIndex.Size = new System.Drawing.Size(60, 22);
            this.numericUpDown_HomeIndex.TabIndex = 0;
            this.numericUpDown_HomeIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBox_RavenName
            // 
            this.textBox_RavenName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RavenName.Font = new System.Drawing.Font("PMingLiU", 9F);
            this.textBox_RavenName.Location = new System.Drawing.Point(0, 0);
            this.textBox_RavenName.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RavenName.Name = "textBox_RavenName";
            this.textBox_RavenName.Size = new System.Drawing.Size(100, 22);
            this.textBox_RavenName.TabIndex = 1;
            // 
            // RavenSplitSetting
            // 
            this.Controls.Add(this.table_Main);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RavenSplitSetting";
            this.Size = new System.Drawing.Size(200, 22);
            this.table_Main.ResumeLayout(false);
            this.table_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HomeIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_Main;
        private System.Windows.Forms.NumericUpDown numericUpDown_HomeIndex;
        private System.Windows.Forms.TextBox textBox_RavenName;
    }
}
