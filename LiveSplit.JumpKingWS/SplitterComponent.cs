using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.JumpKingWS;
public class SplitterComponent : IComponent {
	public string ComponentName { get { return ""; } }
	public float HorizontalWidth { get { return 0; } }
	public float MinimumHeight { get { return 0; } }
	public float VerticalHeight { get { return 0; } }
	public float MinimumWidth { get { return 0; } }
	public float PaddingTop { get { return 0; } }
	public float PaddingBottom { get { return 0; } }
	public float PaddingLeft { get { return 0; } }
	public float PaddingRight { get { return 0; } }
	public IDictionary<string, Action> ContextMenuControls { get { return null; } }
	public TimerModel Model { get; set; }
	public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) { }
	public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) { }
	public Control GetSettingsControl(LayoutMode mode) { return default; }
	public XmlNode GetSettings(XmlDocument document) { return default; }
	public void SetSettings(XmlNode document) { ; }

	public SplitterComponent(LiveSplitState state) {
	}

	public void Update(IInvalidator invalidator, LiveSplitState lvstate, float width, float height, LayoutMode mode) {
	}
	public void OnReset(object sender, TimerPhase e) {
	}
	public void OnPause(object sender, EventArgs e) {
	}
	public void OnResume(object sender, EventArgs e) {
	}
	public void OnStart(object sender, EventArgs e) {
	}
	public void OnSplit(object sender, EventArgs e) {
	}
	public void OnUndoSplit(object sender, EventArgs e) {
	}
	public void OnSkipSplit(object sender, EventArgs e) {
	}

	public void Dispose() {
		if (Model != null) {
			Model.CurrentState.OnReset -= OnReset;
			Model.CurrentState.OnPause -= OnPause;
			Model.CurrentState.OnResume -= OnResume;
			Model.CurrentState.OnStart -= OnStart;
			Model.CurrentState.OnSplit -= OnSplit;
			Model.CurrentState.OnUndoSplit -= OnUndoSplit;
			Model.CurrentState.OnSkipSplit -= OnSkipSplit;
		}
	}
}