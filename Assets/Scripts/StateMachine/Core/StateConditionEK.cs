using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateConditionEK : IStaetComponentEK
{
	private bool isCached = false;
	private bool cachedStatement = default;
	internal StateConditionSOEK originSO;
	protected StateConditionSOEK OriginSO => originSO;
	protected abstract bool Statement();

	public void OnStateEnter()
	{
		throw new System.NotImplementedException();
	}

	public void OnStateExit()
	{
		throw new System.NotImplementedException();
	}
}
