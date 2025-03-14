using System;
using System.Diagnostics;
using System.Xml;
using CommonCom.Util;
using LiveSplit.JumpKingWS.State;

namespace LiveSplit.JumpKingWS.Split;

public class ScreenSplit: SplitBase
{
    const string NUMBER = "Number";
    public override SplitType SplitType => SplitType.Screen;
    public override string FullName => $"{SplitType.GetName()}-{number}";
    public int number;
    private bool needCheckUndo;

    public ScreenSplit(): base() {}
    public ScreenSplit(int p_number) {
        number = p_number;
        needCheckUndo = false;
    }
    public ScreenSplit(XmlNode node): base(node) {}
    protected override void SetDefault()
    {
        number = 1;
    }
    public override void SetFromXml(XmlNode node)
    {
        number = int.Parse(node[NUMBER].InnerText);
    }

    public override XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splitElement = base.GetXmlElement(document);
        
        XmlElement indexElement = document.CreateElement(NUMBER);
        indexElement.InnerText = number.ToString();
        splitElement.AppendChild(indexElement);

        return splitElement;
    }
    
    public override bool CheckSplit()
    {
        if (!ScreenState.HasLandedScreen(number))
        {
            if (ScreenState.HasSeenScreen(number)) 
            {
                needCheckUndo = true;
                return true;
            }
            return false;
        }
        return true;
    }
    public override void OnSplit(int splitIndex)
    {
        base.OnSplit(splitIndex);

        if (needCheckUndo)
        {
            SplitManager.SetUndoSplit(splitIndex, this);
            needCheckUndo = false;
        }
    }
    public override UndoResult CheckUndo()
    {
        if (ScreenState.HasLandedScreen(number)) {
            return UndoResult.Remove;
        } else if (ScreenState.HasSeenScreen(number)) {
            return UndoResult.Skip;
        } else {
            return UndoResult.Undo;
        }
    }
}