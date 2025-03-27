using System.Xml;
using CommonCom.Util;

namespace LiveSplit.JumpKingWS.Split;

public class ManualSplit: SplitBase
{
    public override SplitType SplitType => SplitType.Manual;
    public override string FullName => SplitType.GetName();

    public ManualSplit(): base() {}
    public ManualSplit(XmlNode node): base(node) {}
    protected override void SetDefault() {}
    public override void SetFromXml(XmlNode node) {}
    // public virtual XmlElement GetXmlElement(XmlDocument document);

    public override bool CheckSplit()
    {
        return false;
    }
    // public override void OnSplit(int splitIndex)
    public override UndoResult CheckUndo()
    {
        return UndoResult.Remove;
    }
}