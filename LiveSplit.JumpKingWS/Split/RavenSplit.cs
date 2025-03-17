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
    const string RAVENNAME = "RavenName";
    const string HOMEINDEX1 = "HomeIndex1";
    public override SplitType SplitType => SplitType.Raven;
    public override string FullName => $"{SplitType.GetName()}-{RavenName},{HomeIndex1}";
    public string RavenName;
    public int HomeIndex1;

    public RavenSplit(): base() {}
    public RavenSplit(string p_ravenName, int p_homeIndex1) {
        RavenName = p_ravenName;
        HomeIndex1 = p_homeIndex1;
    }
    public RavenSplit(XmlNode node): base(node) {}
    protected override void SetDefault()
    {
        RavenName = "raven";
        HomeIndex1 = 1;
    }
    public override void SetFromXml(XmlNode node)
    {
        RavenName = node[RAVENNAME].InnerText;
        HomeIndex1 = int.Parse(node[HOMEINDEX1].InnerText);
    }
    public override XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splitElement = base.GetXmlElement(document);
        XmlElement ravenNameElement = document.CreateElement(RAVENNAME);
        ravenNameElement.InnerText = RavenName;
        splitElement.AppendChild(ravenNameElement);

        XmlElement homeIndexElement = document.CreateElement(HOMEINDEX1);
        homeIndexElement.InnerText = HomeIndex1.ToString();
        splitElement.AppendChild(homeIndexElement);

        return splitElement;
    }

    public override bool CheckSplit()
    {
        return RavenState.HasRavenFlee(RavenName, HomeIndex1-1);
    }
    // public override void OnSplit(int splitIndex);
    public override UndoResult CheckUndo()
    {
        return UndoResult.Remove;
    }
}