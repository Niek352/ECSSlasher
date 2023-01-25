namespace StateMachine.Interfaces
{
	public interface IStateMachine
	{
		GameEntity Owner { get; }
		void ChangeState<TState>() where TState : IState;
		void Update(float deltaTime);
		TState GetState<TState>() where TState : IState;
	}
}