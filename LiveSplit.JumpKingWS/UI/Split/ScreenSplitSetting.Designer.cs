namespace LiveSplit.JumpKingWS.UI.Split
{
    partial class ScreenSplitSetting
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
            this.components = new System.ComponentModel.Container();
            this.table_Main = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown_Number = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.table_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Number)).BeginInit();
            this.SuspendLayout();
            // 
            // table_Main
            // 
            this.table_Main.ColumnCount = 2;
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.Controls.Add(this.numericUpDown_Number, 0, 0);
            this.table_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_Main.Location = new System.Drawing.Point(0, 0);
            this.table_Main.Margin = new System.Windows.Forms.Padding(0);
            this.table_Main.Name = "table_Main";
            this.table_Main.RowCount = 1;
            this.table_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.Size = new System.Drawing.Size(200, 22);
            this.table_Main.TabIndex = 0;
            // 
            // numericUpDown_Number
            // 
            this.numericUpDown_Number.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_Number.Font = new System.Drawing.Font("PMingLiU", 9F);
            this.numericUpDown_Number.Location = new System.Drawing.Point(0, 0);
            this.numericUpDown_Number.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDown_Number.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_Number.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Number.Name = "numericUpDown_Number";
            this.numericUpDown_Number.Size = new System.Drawing.Size(60, 22);
            this.numericUpDown_Number.TabIndex = 0;
            this.numericUpDown_Number.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ScreenSplitSetting
            // 
            this.Controls.Add(this.table_Main);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ScreenSplitSetting";
            this.Size = new System.Drawing.Size(200, 22);
            this.table_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Number)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_Main;
        private System.Windows.Forms.NumericUpDown numericUpDown_Number;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
