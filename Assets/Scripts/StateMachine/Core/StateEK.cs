using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEK
{
	internal StateSOEK originSO;
	internal StateMachineEK stateMachine;
	internal StateTransitionEK[] transitions;
	internal StateActionEK[] actions;

	internal StateEK() { }

	public StateEK(
		StateSOEK originSO,
		StateMachineEK stateMachine,
		StateTransitionEK[] transitions,
		StateActionEK[] actions)
	{
		this.originSO = originSO;
		this.stateMachine = stateMachine;
		this.transitions = transitions;
		this.actions = actions;
	}

	public void OnStateEnter()
	{
		void OnStateEnter(IStaetComponentEK[] comps)
		{
			for (int i=0; i<comps.Length;i++)
			{
				comps[i].OnStateEnter();
			}
		}
		OnStateEnter(transitions);
		OnStateEnter(actions);
	}

	public void OnUpdate()
	{
		for(int i=0; i<actions.Length; i++)
		{
			actions[i].OnUpdate();
		}
	}

	public void OnStateExit()
	{
		void OnStateExit(IStaetComponentEK[] comps)
		{
			for(int i=0; i<comps.Length; i++)
			{
				comps[i].OnStateExit();
			}
		}
		OnStateExit(transitions);
		OnStateExit(actions);
	}

	public bool TryGetTransition(out StateEK state)
	{
		state = null;

		for(int i=0; i<transitions.Length; i++)
		{
			if (transitions[i].TryGetTranstion(out state))
				break;
		}

		for(int i=0; i<transitions.Length; i++)
		{
			transitions[i].ClearConditionsCache();
		}

		return state != null;
	}
}
