using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateActionEK : IStaetComponentEK
{
	internal StateActionSOEK originSO;
	protected StateActionSOEK OriginSO => originSO;

	public abstract void OnUpdate();

	public virtual void Awake(StateMachineEK sateMachine) { }

	public virtual void OnStateEnter() { }

	public virtual void OnStateExit() { }

	public enum SpecificMoment
	{
		OnStateEnter, OnStateExit, OnUpdate,
	}
}
