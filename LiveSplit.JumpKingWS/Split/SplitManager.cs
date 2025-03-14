using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using CommonCom;

namespace LiveSplit.JumpKingWS.Split;

public static class SplitManager
{
    public readonly static List<SplitBase> SplitList;
    private static (int, SplitBase)? undoSplit;
    private static int currentIndex => Component.State?.CurrentSplitIndex ?? -1;

    static SplitManager()
    {
        SplitList = [
            new ScreenSplit(6),
            new ScreenSplit(11),
            new ScreenSplit(15),
            new ScreenSplit(20),
            new ScreenSplit(26),
            // new ScreenSplit(33),
            // new ScreenSplit(37),
            // new ScreenSplit(40),
            new RavenSplit("raven", 1),
            new ItemSplit(Item.Cap, 1),
            new AchievementSplit(Achievement.FALL_100),
            new EndingSplit(Ending.Normal),
        ];
        undoSplit = null;
        // Debug.WriteLine(GetXmlElement(new XmlDocument()).OuterXml);
    }

    public static void Clear()
    {
        SplitList.Clear(); 
        undoSplit = null;
    }
    public static void AddSplits(IEnumerable<SplitBase> splitList)
    {
        SplitList.AddRange(splitList);
    }

    public static void SetUndoSplit(int index, SplitBase split)
    {
        Debug.WriteLine($"[UndoSplit] Add undosplit {split.SplitType} at {index}");
        if (undoSplit==null) {
            undoSplit = (index, split);
        }
    }
    public static void RemoveUndoSplit()
    {
        Debug.WriteLine($"[UndoSplit] Remove undosplit");
        undoSplit = null;
    }

    public static void SetSplitFromXml(XmlNode splitsNode)
    {
        Clear();
        foreach (XmlNode node in splitsNode.SelectNodes(".//Split"))
        {
            try
            {
                switch(node.Attributes["type"]?.Value) 
                {
                    case "Manual":
                        SplitList.Add(new ManualSplit(node));
                        break;
                    case "Screen":
                        SplitList.Add(new ScreenSplit(node));
                        break;
                    case "Item":
                        SplitList.Add(new ItemSplit(node));
                        break;
                    case "Raven":
                        SplitList.Add(new RavenSplit(node));
                        break;
                    case "Achievement":
                        SplitList.Add(new AchievementSplit(node));
                        break;
                    case "Ending":
                        SplitList.Add(new EndingSplit(node));
                        break;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
    public static XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splits = document.CreateElement("Splits");

        // add offset to make reading easier
        int offset = 0;
        foreach (SplitBase split in SplitList)
        {
            XmlElement splitElement = split.GetXmlElement(document);
            splitElement.SetAttribute("offset", offset.ToString());
            splits.AppendChild(splitElement);
            offset++;
        }

        return splits;
    }

    public static void UpdatSplits()
    {
        int lastIndex = currentIndex-1;
        int undoIndex;
        SplitBase split;
        bool isSkip = false;
        while (0<=currentIndex && currentIndex<SplitList.Count)
        {
            lastIndex = currentIndex;
            split = SplitList[currentIndex];
            if (split.CheckSplit()) {
                if (!isSkip || currentIndex == Component.Run.Count-1) {
                    isSkip = true;
                    Component.Timer.Split();
                } else {
                    Component.Timer.SkipSplit();
                }
            }

            if (currentIndex==lastIndex) {
                break;
            } else {
                split.OnSplit(lastIndex);
            }
        }

        if (undoSplit!=null) {
            (undoIndex, split) = undoSplit.Value;
            switch (split.CheckUndo())
            {
                case UndoResult.Skip:
                    break;
                case UndoResult.Undo:
                    while (currentIndex>undoIndex) {
                        lastIndex = currentIndex;
                        Component.Timer.UndoSplit();
                        if (currentIndex==lastIndex) break;
                    }
                    if (currentIndex==undoIndex) {
                        RemoveUndoSplit();
                    }
                    break;
                case UndoResult.Remove:
                    RemoveUndoSplit();
                    break;
            }
        }
    }
}