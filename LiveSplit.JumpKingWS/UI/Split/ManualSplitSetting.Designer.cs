namespace LiveSplit.JumpKingWS.UI.Split
{
    partial class ManualSplitSetting
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
            this.SuspendLayout();
            // 
            // table_Main
            // 
            this.table_Main.ColumnCount = 1;
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_Main.Location = new System.Drawing.Point(0, 0);
            this.table_Main.Margin = new System.Windows.Forms.Padding(0);
            this.table_Main.Name = "table_Main";
            this.table_Main.RowCount = 1;
            this.table_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_Main.Size = new System.Drawing.Size(200, 26);
            this.table_Main.TabIndex = 0;
            // 
            // ManualSplitSetting
            // 
            this.Controls.Add(this.table_Main);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ManualSplitSetting";
            this.Size = new System.Drawing.Size(200, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_Main;
    }
}
