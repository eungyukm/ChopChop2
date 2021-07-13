using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineEK : MonoBehaviour
{
	[SerializeField] private TransitionTableSOEK transitionTableSO = default;

	private readonly Dictionary<Type, Component> cachedComponents = new Dictionary<Type, Component>();
	internal StateEK currentState;

	private void Awake()
	{
		currentState.OnStateEnter();
	}

	public new bool TryGetComponent<T>(out T component) where T : Component
	{
		var type = typeof(T);
		if(!cachedComponents.TryGetValue(type, out var value))
		{
			if (base.TryGetComponent<T>(out component))
				cachedComponents.Add(type, component);

			return component != null;
		}

		component = (T)value;
		return true;
	}

	public T GetAddComponent<T>() where T : Component
	{
		if(!TryGetComponent<T>(out var component))
		{
			component = gameObject.AddComponent<T>();
			cachedComponents.Add(typeof(T), component);
		}

		return component;
	}

	public new T GetComponent<T>() where T : Component
	{
		return TryGetComponent(out T component)
			? component : throw new InvalidOperationException($"{typeof(T).Name} not found in {name}.");
	}

	private void Update()
	{
		if (currentState.TryGetTransition(out var transitionState))
			Transition(transitionState);

		currentState.OnUpdate();
	}

	private void Transition(StateEK transitionState)
	{
		currentState.OnStateExit();
		currentState = transitionState;
		currentState.OnStateEnter();
	}
}
