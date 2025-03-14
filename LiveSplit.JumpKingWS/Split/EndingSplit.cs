using System;
using System.Diagnostics;
using System.Xml;
using CommonCom;
using CommonCom.Util;
using LiveSplit.JumpKingWS.State;
using LiveSplit.Model;

namespace LiveSplit.JumpKingWS.Split;

public class EndingSplit: SplitBase
{
    public override SplitType SplitType => SplitType.Ending;
    public override string FullName => $"{SplitType.GetName()}-{endingName}";
    public string endingName;

    public EndingSplit(): base() {}
    public EndingSplit(string p_endingName = "") 
    {
        endingName = p_endingName;
    }
    public EndingSplit(Ending ending): this(ending.GetName()) {}
    public EndingSplit(XmlNode node): base(node) {}
    protected override void SetDefault()
    {
        endingName = "";
    }
    public override void SetFromXml(XmlNode node)
    {
        endingName = node.Attributes["endingName"].Name;
    }
    public override XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splitElement = base.GetXmlElement(document);
        
        XmlElement endingElement = document.CreateElement("EndingName");
        endingElement.InnerText = endingName;
        splitElement.AppendChild(endingElement);

        return splitElement;
    }

    public override bool CheckSplit()
    {
        return EndingState.CheckEnding(endingName);
    }
    // public override void OnSplit(int splitIndex)
    public override UndoResult CheckUndo()
    {
        return UndoResult.Remove;
    }
}