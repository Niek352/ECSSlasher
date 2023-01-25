using Enemy.Movement.Abstract;
using StateMachine.Abstract;
using StateMachine.Interfaces;

namespace Enemy.StateMachine.States.Attack
{
	public class MovementState : State
	{
		private readonly AbstractMovement _movement;

		public bool ReachedTarget => _movement.ReachedTarget;
		public MovementState(AbstractMovement movement, IStateMachine stateMachine) : base(stateMachine)
		{
			_movement = movement;
		}
		
		public override void Enter()
		{
			
		}
		
		public override void Update(float deltaTime)
		{
			if (_movement.ReachedTarget)
			{
				StateMachine.ChangeState<AttackState>();
				return;
			}
			
			_movement.Move(deltaTime);			
		}
		
		public override void Exit()
		{
		}
	}
}