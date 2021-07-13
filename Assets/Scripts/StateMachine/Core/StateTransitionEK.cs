using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransitionEK : IStaetComponentEK
{
	public void OnStateEnter()
	{
		throw new System.NotImplementedException();
	}

	public void OnStateExit()
	{
		throw new System.NotImplementedException();
	}

	public bool TryGetTranstion(out StateEK state)
	{
		state = null;
		return state != null;
	}

	internal void ClearConditionsCache()
	{

	}
}
