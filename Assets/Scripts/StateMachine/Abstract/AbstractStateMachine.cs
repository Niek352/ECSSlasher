using StateMachine.Interfaces;

namespace StateMachine.Abstract
{
	public abstract class AbstractStateMachine : IStateMachine
	{
		public GameEntity Owner { get; }

		protected AbstractStateMachine(GameEntity owner)
		{
			Owner = owner;
		}
		
		public abstract void ChangeState<TState>() where TState : IState;
		public abstract void Initialize<TState>() where TState : IState;
		public abstract void Update(float deltaTime);
		public abstract TState GetState<TState>() where TState : IState;
	}

}