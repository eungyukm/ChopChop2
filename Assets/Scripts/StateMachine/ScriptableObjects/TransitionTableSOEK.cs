using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Transition Table", menuName = "State Machines/Transition Table EK")]
public class TransitionTableSOEK : ScriptableObject
{
	[Serializable]
	public struct TransitonItem
	{
		public StateSOEK FromSate;
		public StateSOEK ToStae;
		public CondionUsage[] Conditons;
	}

	[Serializable]
	public struct CondionUsage
	{
		public Result ExpectedResult;
		public StateConditionSOEK Condition;
		public Operator Operator;
	}

	public enum Result { True, False }
	public enum Operator { And, Or }
}

