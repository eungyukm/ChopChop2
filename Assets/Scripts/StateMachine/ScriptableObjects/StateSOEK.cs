using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "State Machines/StateEK")]
public class StateSOEK : ScriptableObject
{
	[SerializeField] private StateActionSOEK[] action = null;

	internal StateEK GetState(StateMachineEK stateMachine, Dictionary<ScriptableObject, object> createInstances)
	{
		if (createInstances.TryGetValue(this, out var obj))
			return (StateEK)obj;

		var state = new StateEK();
		createInstances.Add(this, state);

		return state;
	}
}
