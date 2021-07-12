﻿using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class DialogueBehaviour : PlayableBehaviour
{
	[SerializeField] private DialogueLineSO _dialogueLine = default;
	[SerializeField] private bool _pauseWhenClipEnds = default; //This won't work if the clip ends on the very last frame of the Timeline

	[HideInInspector] public CutsceneManager cutsceneManager;

	private bool _dialoguePlayed;

	/// <summary>
	/// Displays a line of dialogue on screen by interfacing with the <c>CutsceneManager</c>. 
	/// </summary>
	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
		if (_dialoguePlayed)
			return;

		if (Application.isPlaying)  //TODO: Find a way to "play" dialogue lines even when scrubbing the Timeline not in Play Mode
		{
			// Need to ask the CutsceneManager if the cutscene is playing, since the graph is not actually stopped/paused: it's just going at speed 0.
			if (playable.GetGraph().IsPlaying()
				&& cutsceneManager.IsCutscenePlaying)
			{
				if (_dialogueLine != null)
				{
					cutsceneManager.PlayDialogueFromClip(_dialogueLine);
					_dialoguePlayed = true;
				}
				else
				{
					Debug.LogWarning("This clip contains no DialogueLine");
				}
			}
		}
	}

	public override void OnBehaviourPause(Playable playable, FrameData info)
	{
		// The check on _dialoguePlayed is needed because OnBehaviourPause is called also at the beginning of the Timeline,
		// so we need to make sure that the Timeline has actually gone through this clip (i.e. called OnBehaviourPlay) at least once before we stop it
		if (Application.isPlaying
			&& playable.GetGraph().IsPlaying()
			&& !playable.GetGraph().GetRootPlayable(0).IsDone()
			&& _dialoguePlayed)
		{
			if (_pauseWhenClipEnds)
				cutsceneManager.PauseTimeline();
		}
	}
}
