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
    public override SplitType SplitType => SplitType.Achievement;
    public override string FullName => $"{SplitType.GetName()}-{code.GetName()}";
    public Achievement code;

    public AchievementSplit(): base() {}
    public AchievementSplit(Achievement p_code) {
        code = p_code;
    }
    public AchievementSplit(XmlNode node): base(node) {}
    protected override void SetDefault()
    {
        code = 0;
    }
    public override void SetFromXml(XmlNode node)
    {
        code = (Achievement)int.Parse(node.Attributes["code"].Name);
    }
    public override XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splitElement = base.GetXmlElement(document);
        
        XmlElement codeElement = document.CreateElement("Code");
        codeElement.InnerText = ((int)code).ToString();
        splitElement.AppendChild(codeElement);

        return splitElement;
    }

    public override bool CheckSplit()
    {
        return AchievementState.HasAchievement(code);
    }
    public override void OnSplit(int splitIndex)
    {
        TimeSpan igt = Component.State.CurrentTime.GameTime ?? TimeSpan.Zero;
        Debug.WriteLine($"[Split-{splitIndex}] {SplitType}-{code.GetName()} at {igt:hh\\:mm\\:ss\\.fff}");
    }
    public override UndoResult CheckUndo()
    {
        return UndoResult.Remove;
    }
}