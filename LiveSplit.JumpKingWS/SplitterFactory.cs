#if !DebugInfo
using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;

namespace LiveSplit.JumpKingWS;
public class SplitterFactory : IComponentFactory {
    public string ComponentName { get { return "" + this.Version.ToString(); } }
    public string Description { get { return ""; } }
    public ComponentCategory Category { get { return ComponentCategory.Control; } }
    public IComponent Create(LiveSplitState state) { return new SplitterComponent(state); }
    public string UpdateName { get { return this.ComponentName; } }
    public string UpdateURL { get { return ""; } }
    public string XMLURL { get { return ""; } }
    public Version Version { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
}
#endif