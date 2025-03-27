using System.Xml;
using CommonCom;
using CommonCom.Util;
using LiveSplit.JumpKingWS.State;

namespace LiveSplit.JumpKingWS.Split;

public class AchievementSplit: SplitBase
{
    const string CODE_NODENAME = "Code";
    public override SplitType SplitType => SplitType.Achievement;
    public override string FullName => $"{SplitType.GetName()}-{Code.GetName()}";
    public Achievement Code;

    public AchievementSplit(): base() {}
    public AchievementSplit(Achievement p_code)
    {
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
    // public override void OnSplit(int splitIndex);
    public override UndoResult CheckUndo()
    {
        return UndoResult.Remove;
    }
}