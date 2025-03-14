using System;
using System.ComponentModel;
using System.Windows.Forms;
using LiveSplit.JumpKingWS.Split;

namespace LiveSplit.JumpKingWS.UI.Split;
[TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<SplitSetting, UserControl>))]
public abstract class SplitSetting : UserControl
{
    public abstract SplitBase Split {get;}

    public virtual new void Dispose(bool disposing) 
    {
        RemoveHandlers();
        base.Dispose(disposing);
    }
    
    protected abstract void SetupControlValues();
    protected abstract void AddHandlers();
    protected abstract void RemoveHandlers();
}

// Taken from https://stackoverflow.com/questions/6817107
public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
{
    public AbstractControlDescriptionProvider()
        : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
    {
    }

    public override Type GetReflectionType(Type objectType, object instance)
    {
        if (objectType == typeof(TAbstract))
            return typeof(TBase);

        return base.GetReflectionType(objectType, instance);
    }

    public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
    {
        if (objectType == typeof(TAbstract))
            objectType = typeof(TBase);

        return base.CreateInstance(provider, objectType, argTypes, args);
    }
}
