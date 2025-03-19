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
        comboBox_Item.SelectedItem = itemSplit.Item;

        numericUpDown_Count.Value = itemSplit.Count;

        toolTip.SetToolTip(comboBox_Item, "Item Name");
        toolTip.SetToolTip(numericUpDown_Count, "Count");
    }
    protected override void AddHandlers() 
    {
        comboBox_Item.SelectedIndexChanged += OnItemChanged;
        numericUpDown_Count.ValueChanged += OnCountChanged;
    }
    protected override void RemoveHandlers() 
    {
        comboBox_Item.SelectedIndexChanged -= OnItemChanged;
        numericUpDown_Count.ValueChanged -= OnCountChanged;
    }
    private void OnItemChanged(object sender, EventArgs e)
    {
        itemSplit.Item = (Item)comboBox_Item.SelectedItem;
    }
    private void OnCountChanged(object sender, EventArgs e)
    {
        itemSplit.Count = (int)numericUpDown_Count.Value;
    }

}
