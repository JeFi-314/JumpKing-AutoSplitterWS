using LiveSplit.JumpKingWS.State;
using CommonCom;
using System.Xml;
using System;
using CommonCom.Util;
using LiveSplit.Model;
using System.Diagnostics;

namespace LiveSplit.JumpKingWS.Split;

public class ItemSplit: SplitBase
{
    public override SplitType SplitType => SplitType.Item;
    public override string FullName => $"{SplitType.GetName()}-{item.GetName()},{count}";
    public Item item;
    public int count;
    
    public ItemSplit(): base() {}
    public ItemSplit(Item p_item, int p_count) {
        item = p_item;
        count = p_count;
    }
    public ItemSplit(XmlNode node): base(node) {}
    protected override void SetDefault()
    {
        item = (Item)0;
        count = 1;
    }
    public override void SetFromXml(XmlNode node)
    {
        item = (Item)int.Parse(node.Attributes["count"].Name);
        count = int.Parse(node.Attributes["count"].Name);
    }
    public override XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splitElement = base.GetXmlElement(document);

        XmlElement itemElement = document.CreateElement("Item");
        itemElement.InnerText = ((int)item).ToString();
        splitElement.AppendChild(itemElement);

        XmlElement countElement = document.CreateElement("Count");
        countElement.InnerText = count.ToString();
        splitElement.AppendChild(countElement);

        return splitElement;
    }

    public override bool CheckSplit()
    {
        return ItemState.HasItems(item, count);
    }
    // public override void OnSplit(int splitIndex)
    public override UndoResult CheckUndo()
    {
        return UndoResult.Remove;
    }
}