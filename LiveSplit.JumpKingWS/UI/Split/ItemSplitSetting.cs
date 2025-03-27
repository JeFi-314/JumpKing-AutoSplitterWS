using System;
using System.Linq;
using CommonCom;
using CommonCom.Util;
using LiveSplit.JumpKingWS.Split;

namespace LiveSplit.JumpKingWS.UI.Split;
public partial class ItemSplitSetting : SplitSetting
{
    const string comboBox_Item_TIP = "Item Name";
    const string numericUpDown_Count_TIP = "Count";
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

        toolTip.SetToolTip(comboBox_Item, comboBox_Item_TIP);
        toolTip.SetToolTip(numericUpDown_Count, numericUpDown_Count_TIP);
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
