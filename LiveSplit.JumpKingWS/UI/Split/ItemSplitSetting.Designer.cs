namespace LiveSplit.JumpKingWS.UI.Split
{
    partial class ItemSplitSetting
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
            this.comboBox_Item = new System.Windows.Forms.ComboBox();
            this.numericUpDown_Count = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.table_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Count)).BeginInit();
            this.SuspendLayout();
            // 
            // table_Main
            // 
            this.table_Main.ColumnCount = 3;
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.table_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.Controls.Add(this.comboBox_Item, 0, 0);
            this.table_Main.Controls.Add(this.numericUpDown_Count, 1, 0);
            this.table_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_Main.Location = new System.Drawing.Point(0, 0);
            this.table_Main.Margin = new System.Windows.Forms.Padding(0);
            this.table_Main.Name = "table_Main";
            this.table_Main.RowCount = 2;
            this.table_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_Main.Size = new System.Drawing.Size(200, 22);
            this.table_Main.TabIndex = 0;
            // 
            // comboBox_Item
            // 
            this.comboBox_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_Item.DropDownHeight = 240;
            this.comboBox_Item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Item.Font = new System.Drawing.Font("PMingLiU", 10F);
            this.comboBox_Item.FormattingEnabled = true;
            this.comboBox_Item.IntegralHeight = false;
            this.comboBox_Item.Location = new System.Drawing.Point(0, 0);
            this.comboBox_Item.Margin = new System.Windows.Forms.Padding(0);
            this.comboBox_Item.Name = "comboBox_Item";
            this.comboBox_Item.Size = new System.Drawing.Size(110, 21);
            this.comboBox_Item.TabIndex = 0;
            // 
            // numericUpDown_Count
            // 
            this.numericUpDown_Count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_Count.Font = new System.Drawing.Font("PMingLiU", 9F);
            this.numericUpDown_Count.Location = new System.Drawing.Point(110, 0);
            this.numericUpDown_Count.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDown_Count.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDown_Count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Count.Name = "numericUpDown_Count";
            this.numericUpDown_Count.Size = new System.Drawing.Size(60, 22);
            this.numericUpDown_Count.TabIndex = 1;
            this.numericUpDown_Count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ItemSplitSetting
            // 
            this.Controls.Add(this.table_Main);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ItemSplitSetting";
            this.Size = new System.Drawing.Size(200, 22);
            this.table_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Count)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_Main;
        private System.Windows.Forms.ComboBox comboBox_Item;
        private System.Windows.Forms.NumericUpDown numericUpDown_Count;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
