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
    const string ENDING = "Ending";
    public override SplitType SplitType => SplitType.Ending;
    public override string FullName => $"{SplitType.GetName()}-{Ending.GetName()}";
    public Ending Ending;

    public EndingSplit(): base() {}
    public EndingSplit(Ending p_endingName) 
    {
        Ending = p_endingName;
    }
    public EndingSplit(XmlNode node): base(node) {}
    protected override void SetDefault()
    {
        Ending = Ending.Normal;
    }
    public override void SetFromXml(XmlNode node)
    {
        Ending = (Ending)int.Parse(node[ENDING].InnerText);
    }
    public override XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splitElement = base.GetXmlElement(document);
        
        XmlElement endingElement = document.CreateElement(ENDING);
        endingElement.InnerText = ((int)Ending).ToString();
        splitElement.AppendChild(endingElement);

        return splitElement;
    }

    public override bool CheckSplit()
    {
        return EndingState.CheckEnding(Ending);
    }
    // public override void OnSplit(int splitIndex)
    public override UndoResult CheckUndo()
    {
        return UndoResult.Remove;
    }
}