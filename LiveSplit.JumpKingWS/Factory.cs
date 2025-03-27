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
    public string ComponentName => "JumpKing AutoSplitterWS";
    public string Description => "AutoSplitter for JumpKing based on Steam workshop";
    public ComponentCategory Category => ComponentCategory.Control;
    public IComponent Create(LiveSplitState state) => new Component(state);

    // The component name displayed in the update message box dialog.
    public string UpdateName => ComponentName;

    // Updater in LiveSplit will find the files to add/change/remove based on this URL.
    public string UpdateURL => "https://raw.githubusercontent.com/JeFi-314/JumpKing-AutoSplitterWS/main/";

    // The update history information, which will be read by UpdaterInternal.
    public string XMLURL => $"{UpdateURL}Components/Updates.xml";

    public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
}