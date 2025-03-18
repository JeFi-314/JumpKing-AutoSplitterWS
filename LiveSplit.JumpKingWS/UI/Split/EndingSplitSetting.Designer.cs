namespace LiveSplit.JumpKingWS.UI.Split
{
    partial class EndingSplitSetting
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
            this.combo_Ending = new System.Windows.Forms.ComboBox();
            this.table_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_Main
            // 
            this.table_Main.ColumnCount = 2;
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.Controls.Add(this.combo_Ending, 0, 0);
            this.table_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_Main.Location = new System.Drawing.Point(0, 0);
            this.table_Main.Margin = new System.Windows.Forms.Padding(0);
            this.table_Main.Name = "table_Main";
            this.table_Main.RowCount = 1;
            this.table_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.Size = new System.Drawing.Size(200, 22);
            this.table_Main.TabIndex = 0;
            // 
            // combo_Ending
            // 
            this.combo_Ending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_Ending.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Ending.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.combo_Ending.FormattingEnabled = true;
            this.combo_Ending.Location = new System.Drawing.Point(0, 0);
            this.combo_Ending.Margin = new System.Windows.Forms.Padding(0);
            this.combo_Ending.Name = "combo_Ending";
            this.combo_Ending.Size = new System.Drawing.Size(120, 21);
            this.combo_Ending.TabIndex = 0;
            // 
            // EndingSplitSetting
            // 
            this.Controls.Add(this.table_Main);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EndingSplitSetting";
            this.Size = new System.Drawing.Size(200, 22);
            this.table_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_Main;
        private System.Windows.Forms.ComboBox combo_Ending;
    }
}
