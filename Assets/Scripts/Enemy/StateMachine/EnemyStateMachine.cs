using System;
using System.Collections.Generic;
using Enemy.Attack.Abstract;
using Enemy.Movement.Abstract;
using Enemy.StateMachine.States;
using Enemy.StateMachine.States.Attack;
using StateMachine.Abstract;
using StateMachine.Interfaces;

namespace Enemy.StateMachine
{
	public class EnemyStateMachine : AbstractStateMachine
	{
		private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
		private IState _currentState;
		
		public EnemyStateMachine(GameEntity owner, AbstractAttack attack, AbstractMovement movement) : base(owner)
		{
			_states.Add(typeof(AttackState), new AttackState(attack, this));
			_states.Add(typeof(MovementState), new MovementState(movement, this));
			_states.Add(typeof(InitializeState), new InitializeState(this));
		}

		public override void Initialize<TState>()
		{
			_currentState = _states[typeof(TState)];
			_currentState.Enter();
		}
		
		public override void Update(float deltaTime) 
			=> _currentState.Update(deltaTime);

		public override TState GetState<TState>() 
			=> (TState)_states[typeof(TState)];

		public override void ChangeState<TState>()
		{
			_currentState.Exit();
			_currentState = _states[typeof(TState)];
			_currentState.Enter();
		}
	}
}