using System;
using System.Diagnostics;
using System.Xml;
using CommonCom.Util;

namespace LiveSplit.JumpKingWS.Split;

public abstract class SplitBase
{
    public abstract SplitType SplitType {get;}
    public abstract string FullName {get;}

    public SplitBase()
    {
        SetDefault();
    }
    public SplitBase(XmlNode node)
    {
        try {
            SetFromXml(node);
        } catch (Exception ex) {
            SetDefault();
            Debug.WriteLine(ex);
        }
    }
    public T Clone<T>() where T: SplitBase
    {
        return (T)this.MemberwiseClone();
    }
    protected abstract void SetDefault();
    public abstract void SetFromXml(XmlNode node);
    public virtual XmlElement GetXmlElement(XmlDocument document)
    {
        XmlElement splitElement = document.CreateElement("Split");
        splitElement.SetAttribute("type", SplitType.GetName());
        return splitElement;
    }

    public abstract bool CheckSplit();
    public virtual void OnSplit(int splitIndex)
    {
        TimeSpan igt = Component.State.CurrentTime.GameTime ?? TimeSpan.Zero;
        Debug.WriteLine($"[Split-{splitIndex}] {FullName} at {igt:hh\\:mm\\:ss\\.fff}");
    }
    public abstract UndoResult CheckUndo();
}
