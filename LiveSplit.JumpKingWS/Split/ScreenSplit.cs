using System;
using System.Diagnostics;
using System.Xml;
using CommonCom.Util;
using LiveSplit.JumpKingWS.State;

namespace LiveSplit.JumpKingWS.Split;

public class ScreenSplit: SplitBase
{
    const string NUMBER_NODENAME = "Number";
    public override SplitType SplitType => SplitType.Screen;
    public override string FullName => $"{SplitType.GetName()}-{Number}";
    public int Number;
    private bool needCheckUndo;

    public ScreenSplit(): base() {}
    public ScreenSplit(int p_number) {
        Number = p_number;
        needCheckUndo = false;
    }
    public ScreenSplit(XmlNode node): base(node) {}
    protected override void SetDefault()
    {
        Number = 1;
    }
    public override void SetFromXml(XmlNode node)
    {
        Number = int.Parse(node[NUMBER_NODENAME].InnerText);
    }

    public override XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splitElement = base.GetXmlElement(document);
        
        XmlElement indexElement = document.CreateElement(NUMBER_NODENAME);
        indexElement.InnerText = Number.ToString();
        splitElement.AppendChild(indexElement);

        return splitElement;
    }
    
    public override bool CheckSplit()
    {
        if (!ScreenState.HasLandedScreen(Number))
        {
            if (ScreenState.HasSeenScreen(Number)) 
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
        if (ScreenState.HasLandedScreen(Number)) {
            return UndoResult.Remove;
        } else if (ScreenState.HasSeenScreen(Number)) {
            return UndoResult.Skip;
        } else {
            return UndoResult.Undo;
        }
    }
}