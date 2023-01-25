using StateMachine.Abstract;
using UnityEngine;

namespace StateMachine
{
	public abstract class StateMachineBuilder : ScriptableObject
	{
		public abstract AbstractStateMachine Create(GameEntity owner);
	}
}