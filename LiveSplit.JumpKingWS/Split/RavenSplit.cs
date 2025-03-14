using System;
using System.Diagnostics;
using System.Xml;
using CommonCom;
using CommonCom.Util;
using LiveSplit.JumpKingWS.State;
using LiveSplit.Model;

namespace LiveSplit.JumpKingWS.Split;

public class RavenSplit: SplitBase
{
    public override SplitType SplitType => SplitType.Raven;
    public override string FullName => $"{SplitType.GetName()}-{ravenName},{homeIndex1}";
    public string ravenName;
    public int homeIndex1;

    public RavenSplit(): base() {}
    public RavenSplit(string p_ravenName, int p_homeIndex1) {
        ravenName = p_ravenName;
        homeIndex1 = p_homeIndex1;
    }
    public RavenSplit(XmlNode node): base(node) {}
    protected override void SetDefault()
    {
        ravenName = "";
        homeIndex1 = 1;
    }
    public override void SetFromXml(XmlNode node)
    {
        ravenName = node.Attributes["ravenName"].Name;
        homeIndex1 = int.Parse(node.Attributes["homeIndex"].Name);
    }
    public override XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splitElement = base.GetXmlElement(document);
        XmlElement ravenNameElement = document.CreateElement("RavenName");
        ravenNameElement.InnerText = ravenName;
        splitElement.AppendChild(ravenNameElement);

        XmlElement homeIndexElement = document.CreateElement("HomeIndex");
        homeIndexElement.InnerText = homeIndex1.ToString();
        splitElement.AppendChild(homeIndexElement);

        return splitElement;
    }

    public override bool CheckSplit()
    {
        return RavenState.HasRavenFlee(ravenName, homeIndex1-1);
    }
    // public override void OnSplit(int splitIndex);
    public override UndoResult CheckUndo()
    {
        return UndoResult.Remove;
    }
}