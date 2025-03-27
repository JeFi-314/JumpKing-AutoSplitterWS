using CommonCom.Util;
using LiveSplit.JumpKingWS.Communication;
using LiveSplit.JumpKingWS.Split;
using LiveSplit.JumpKingWS.State;
using LiveSplit.JumpKingWS.UI;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.JumpKingWS;
public class Component : IComponent {
	public string ComponentName => "JumpKing AutoSplitterWS";
	private static readonly LinkedList<Component> InstanceList = [];
	private readonly LinkedListNode<Component> instanceNode;
	public static TimerModel Timer { get; private set; }
	public static LiveSplitState State => Timer?.CurrentState; 
	public static IRun Run => Timer?.CurrentState?.Run; 
	public static Settings Settings;
	public static readonly ConcurrentQueue<Action> ActionQueue = [];
	private static int baseGameTicks = 0;
	private static int lastGameTicks = 0;

	public Component(LiveSplitState state) 
	{
		instanceNode = new LinkedListNode<Component>(this);
		InstanceList.AddLast(instanceNode);
		if (InstanceList.Count > 1) return;

		CommunicationWrapper.Start();
		Settings = new Settings();

		Timer = new TimerModel() { CurrentState = state };
		Timer.InitializeGameTime();

		state.IsGameTimePaused = true;
		state.OnReset += OnReset;
		state.OnPause += OnPause;
		state.OnResume += OnResume;
		state.OnStart += OnStart;
		state.OnSplit += OnSplit;
		state.OnUndoSplit += OnUndoSplit;
		state.OnSkipSplit += OnSkipSplit;
		
		Debug.WriteLine("[Component] Component initialized");
	}

	public void Update(IInvalidator invalidator, LiveSplitState lvstate, float width, float height, LayoutMode mode) 
	{
		if (instanceNode != InstanceList.First) return;

		while (ActionQueue.TryDequeue(out var action))
		{
			try
			{
				action();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"[Component] Exception in Update: {ex}");
			}
		}
	}

	public static void UpdateGameTime(int currentTicks)
	{
        if (currentTicks == lastGameTicks)
        {
            State.IsGameTimePaused = true;
            return;
        }
        State.IsGameTimePaused = false;
        lastGameTicks = currentTicks;

        State.SetGameTime(TimeSpan.FromMilliseconds((currentTicks - baseGameTicks)*17));
	}

	public static void SetBaseTicks()
	{
		baseGameTicks = lastGameTicks;
	}
	public static void SetBaseTicks(int gameTicks)
	{
		baseGameTicks = gameTicks;
	}

	public Control GetSettingsControl(LayoutMode mode) => instanceNode == InstanceList.First ? Settings : new UserControl();
	public void SetSettings(XmlNode node)
	{
		Settings.LoadFromXml(node);
		SplitManager.LoadFromXml(node["Splits"]);
	}
	public XmlNode GetSettings(XmlDocument document)
	{
		XmlElement settingsEle = document.CreateElement("Settings");
		
		Settings.SaveToXml(document, settingsEle);
		settingsEle.AppendChild(SplitManager.GetXmlElement(document));
		return settingsEle;
	}
	public int GetSettingsHashCode()
	{ 
		int hash = Settings.GetHash();
		hash ^= SplitManager.GetHash();
		// Debug.WriteLine($"[Component] hash={hash}");
		return hash;
	}

	#region LiveSplitState Events

	public void OnReset(object sender, TimerPhase e) 
	{
		Debug.WriteLine($"[Timer] Reset");
	}
	public void OnPause(object sender, EventArgs e) 
	{
		Debug.WriteLine($"[Timer] Pause");
	}
	public void OnResume(object sender, EventArgs e) 
	{
		Debug.WriteLine($"[Timer] Resume");
	}
	public void OnStart(object sender, EventArgs e) 
	{
		AchievementState.Reset();
		EndingState.Reset();
		ItemState.Reset();
		RavenState.Reset();
		ScreenState.Reset();
		SetBaseTicks();
		
		Debug.WriteLine($"[Timer] Start");
	}
	public void OnSplit(object sender, EventArgs e) 
	{
		Debug.WriteLine($"[Timer] Split");
	}
	public void OnUndoSplit(object sender, EventArgs e) 
	{
		Debug.WriteLine($"[Timer] UndoSplit");
	}
	public void OnSkipSplit(object sender, EventArgs e) 
	{
		Debug.WriteLine($"[Timer] SkipSplit");
	}

	#endregion

	// NOTE: From LiveSplit.View.TimerForm.SetLayout(layout),
	// if new layout and current Layout have same Component instance,
	// component.Dispose() won't be called. 
	// So using singleton might not work correctly.
	public void Dispose() 
	{
		InstanceList.Remove(instanceNode);
		if (InstanceList.Count > 0) return;

		CommunicationWrapper.Stop();
		while (ActionQueue.TryDequeue(out var _)) {}
		Settings.Dispose();
		Settings = null;
		if (Timer != null) {
			State.OnReset -= OnReset;
			State.OnPause -= OnPause;
			State.OnResume -= OnResume;
			State.OnStart -= OnStart;
			State.OnSplit -= OnSplit;
			State.OnUndoSplit -= OnUndoSplit;
			State.OnSkipSplit -= OnSkipSplit;
		}
		Timer = null;

		Debug.WriteLine("[Component] Component disposed");
	}

	//Ignore UI settings on autosplitter component
	#region UI

	public float HorizontalWidth { get { return 0; } }
	public float MinimumHeight { get { return 0; } }
	public float VerticalHeight { get { return 0; } }
	public float MinimumWidth { get { return 0; } }
	public float PaddingTop { get { return 0; } }
	public float PaddingBottom { get { return 0; } }
	public float PaddingLeft { get { return 0; } }
	public float PaddingRight { get { return 0; } }
	public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) { }
	public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) { }
	public IDictionary<string, Action> ContextMenuControls { get { return null; } }
	
	#endregion
}