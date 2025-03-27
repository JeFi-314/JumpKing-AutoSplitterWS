using LiveSplit.JumpKingWS.State;
using CommonCom;
using System.Xml;
using CommonCom.Util;

namespace LiveSplit.JumpKingWS.Split;

public class ItemSplit: SplitBase
{
    const string ITEM_NODENAME = "Item";
    const string COUNT_NODENAME = "Count";
    public override SplitType SplitType => SplitType.Item;
    public override string FullName => $"{SplitType.GetName()}-{Item.GetName()},{Count}";
    public Item Item;
    public int Count;
    
    public ItemSplit(): base() {}
    public ItemSplit(Item p_item, int p_count)
    {
        Item = p_item;
        Count = p_count;
    }
    public ItemSplit(XmlNode node): base(node) {}
    protected override void SetDefault()
    {
        Item = (Item)0;
        Count = 1;
    }
    public override void SetFromXml(XmlNode node)
    {
        Item = (Item)int.Parse(node[ITEM_NODENAME].InnerText);
        Count = int.Parse(node[COUNT_NODENAME].InnerText);
    }
    public override XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splitElement = base.GetXmlElement(document);

        XmlElement itemElement = document.CreateElement(ITEM_NODENAME);
        itemElement.InnerText = ((int)Item).ToString();
        splitElement.AppendChild(itemElement);

        XmlElement countElement = document.CreateElement(COUNT_NODENAME);
        countElement.InnerText = Count.ToString();
        splitElement.AppendChild(countElement);

        return splitElement;
    }

    public override bool CheckSplit()
    {
        return ItemState.HasItems(Item, Count);
    }
    // public override void OnSplit(int splitIndex)
    public override UndoResult CheckUndo()
    {
        return UndoResult.Remove;
    }
}