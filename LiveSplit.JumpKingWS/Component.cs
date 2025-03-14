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
	public string ComponentName { get { return "JumpKing AutoSplitterWS"; } }
	public static TimerModel Timer { get; private set; }
	public static LiveSplitState State => Timer?.CurrentState; 
	public static IRun Run => Timer?.CurrentState?.Run; 
	public static Settings Settings;
	public static ConcurrentQueue<Action> ActionQueue;
	public static Component Instance;
	private static int startGameTicks = 0;
	private static int lastGameTicks = 0;

	public Component(LiveSplitState state) 
	{
		if (Instance != null) {
			Debug.WriteLine("Try to create multiple instances of autospliter component");
			return;
		}
		Instance = this;
#if DEBUG
		Debugger.Launch();
#endif

		ActionQueue = [];
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
	}

	public void Update(IInvalidator invalidator, LiveSplitState lvstate, float width, float height, LayoutMode mode) 
	{
		if (this != Instance) 
		{
			return;
		}
		
		while (ActionQueue.TryDequeue(out var action))
		{
			try
			{
				action();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Exception: {ex}");
			}
		}
	}

	public static void UpdateGameTime(int currentTicks)
	{
		if (Instance == null) 
		{
			return;
		}

        if (currentTicks == lastGameTicks)
        {
            State.IsGameTimePaused = true;
            return;
        }
        State.IsGameTimePaused = false;
        lastGameTicks = currentTicks;

        State.SetGameTime(TimeSpan.FromMilliseconds((currentTicks - startGameTicks)*17));
	}

	public static void SetStartTicks()
	{
		startGameTicks = lastGameTicks;
	}
	public static void SetStartTicks(int gameTicks)
	{
		startGameTicks = gameTicks;
	}

	public Control GetSettingsControl(LayoutMode mode) => Settings;
	public void SetSettings(XmlNode xmlNode)
	{
		SplitManager.SetSplitFromXml(xmlNode["Splits"]);
	}
	public XmlNode GetSettings(XmlDocument document)
	{
		XmlElement xmlElement = document.CreateElement("Settings");
		xmlElement.AppendChild(SplitManager.GetXmlElement(document));
		return xmlElement;
	}
	public int GetSettingsHashCode()
	{ 
		int hash = GetSettings(new XmlDocument()).OuterXml.GetStableHashCode();
		// Debug.WriteLine(hash);
		return hash;
	}

	#region LiveSplitState Events

	public void OnReset(object sender, TimerPhase e) 
	{
		AchievementState.Reset();
		EndingState.Reset();
		ItemState.Reset();
		RavenState.Reset();
		ScreenState.Reset();
	}
	public void OnPause(object sender, EventArgs e) 
	{
	}
	public void OnResume(object sender, EventArgs e) 
	{
	}
	public void OnStart(object sender, EventArgs e) 
	{
		SetStartTicks();
	}
	public void OnSplit(object sender, EventArgs e) 
	{
	}
	public void OnUndoSplit(object sender, EventArgs e) 
	{
	}
	public void OnSkipSplit(object sender, EventArgs e) 
	{
	}

	#endregion

	public void Dispose() 
	{
		if (this != Instance) {
			return;
		}
		Instance = null;

		ActionQueue = null;
		CommunicationWrapper.Stop();
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