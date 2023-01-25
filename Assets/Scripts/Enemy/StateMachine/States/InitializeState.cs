using Enemy.StateMachine.States.Attack;
using StateMachine.Abstract;
using StateMachine.Interfaces;

namespace Enemy.StateMachine.States
{
	public class InitializeState : State
	{
		private float _delay = 1;
		public InitializeState(IStateMachine stateMachine) : base(stateMachine)
		{
			
		}
		
		public override void Enter()
		{
		}
		
		public override void Update(float deltaTime)
		{
			_delay -= deltaTime;
			if (_delay <= 0)
			{
				StateMachine.ChangeState<MovementState>();
			}
		}
		
		public override void Exit()
		{
			
		}
	}
}