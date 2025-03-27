using System;
using System.Diagnostics;
using System.Xml;
using CommonCom;
using CommonCom.Util;
using LiveSplit.JumpKingWS.State;
using LiveSplit.Model;

namespace LiveSplit.JumpKingWS.Split;

public class AchievementSplit: SplitBase
{
    const string CODE_NODENAME = "Code";
    public override SplitType SplitType => SplitType.Achievement;
    public override string FullName => $"{SplitType.GetName()}-{Code.GetName()}";
    public Achievement Code;

    public AchievementSplit(): base() {}
    public AchievementSplit(Achievement p_code) {
        Code = p_code;
    }
    public AchievementSplit(XmlNode node): base(node) {}
    protected override void SetDefault()
    {
        Code = 0;
    }
    public override void SetFromXml(XmlNode node)
    {
        Code = (Achievement)int.Parse(node[CODE_NODENAME].InnerText);
    }
    public override XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splitElement = base.GetXmlElement(document);
        
        XmlElement codeElement = document.CreateElement(CODE_NODENAME);
        codeElement.InnerText = ((int)Code).ToString();
        splitElement.AppendChild(codeElement);

        return splitElement;
    }

    public override bool CheckSplit()
    {
        return AchievementState.HasAchievement(Code);
    }
    public override void OnSplit(int splitIndex)
    {
        TimeSpan igt = Component.State.CurrentTime.GameTime ?? TimeSpan.Zero;
        Debug.WriteLine($"[Split-{splitIndex}] {SplitType}-{Code.GetName()} at {igt:hh\\:mm\\:ss\\.fff}");
    }
    public override UndoResult CheckUndo()
    {
        return UndoResult.Remove;
    }
}