#if !DebugInfo
using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Diagnostics;
using System.Reflection;

namespace LiveSplit.JumpKingWS;
public class Factory : IComponentFactory {
#if DEBUG
    static Factory()
	{
		Debugger.Launch();
	}
#endif
    public string ComponentName { get { return "JumpKing AutoSplitterWS v" + this.Version.ToString(); } }
    public string Description { get { return ""; } }
    public ComponentCategory Category { get { return ComponentCategory.Control; } }
    public IComponent Create(LiveSplitState state) { return new Component(state); }
    public string UpdateName { get { return this.ComponentName; } }
    public string UpdateURL { get { return ""; } }
    public string XMLURL { get { return "https://github.com/JeFi-314/JumpKing-AutoSplitterWS"; } }
    public Version Version { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
}
#endif