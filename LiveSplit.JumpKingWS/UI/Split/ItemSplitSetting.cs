using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CommonCom;
using CommonCom.Util;
using LiveSplit.JumpKingWS.Split;

namespace LiveSplit.JumpKingWS.UI.Split;
public partial class ItemSplitSetting : SplitSetting
{
    private ItemSplit itemSplit;
    public override SplitBase Split => itemSplit;

    public ItemSplitSetting(ItemSplit split)
    {
        InitializeComponent();

        itemSplit = split;
        SetupControlValues();
        AddHandlers();
    }
    protected override void SetupControlValues()
    {
        var validItems = Enum.GetValues(typeof(Item))
                              .Cast<Item>()
                              .Where(item => !string.IsNullOrEmpty(item.GetName()))
                              .ToList();
        comboBox_Item.DataSource = validItems;
        comboBox_Item.Format += (s, e) =>
        {
            if (e.ListItem is Item item)
            {
                e.Value = item.GetName();
            }
        };

        comboBox_Item.SelectedItem = itemSplit.item;

        numericUpDown_Count.Value = itemSplit.count;
    }
    protected override void AddHandlers() 
    {
        comboBox_Item.SelectedIndexChanged += ItemChanged;
        numericUpDown_Count.ValueChanged += CountChanged;
    }
    protected override void RemoveHandlers() 
    {
        comboBox_Item.SelectedIndexChanged -= ItemChanged;
        numericUpDown_Count.ValueChanged -= CountChanged;
    }
    private void ItemChanged(object sender, EventArgs e)
    {
        itemSplit.item = (Item)comboBox_Item.SelectedItem;
    }
    private void CountChanged(object sender, EventArgs e)
    {
        itemSplit.count = (int)numericUpDown_Count.Value;
    }

}
