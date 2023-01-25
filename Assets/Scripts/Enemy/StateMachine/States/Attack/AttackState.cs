using Enemy.Attack.Abstract;
using StateMachine.Abstract;
using StateMachine.Interfaces;

namespace Enemy.StateMachine.States.Attack
{
	public class AttackState : State
	{
		private readonly AbstractAttack _attack;
		private readonly GameEntity _owner;
		private MovementState _moveState;

		public AttackState(AbstractAttack attack, IStateMachine stateMachine) : base(stateMachine)
		{
			_attack = attack;
			_owner = stateMachine.Owner;
		}
		
		public override void Enter()
		{
			_moveState = StateMachine.GetState<MovementState>();
		}

		public override void Update(float deltaTime)
		{
			if (!_moveState.ReachedTarget)
			{
				StateMachine.ChangeState<MovementState>();
				return;
			}
			
			if (_attack.InCoolDown)
			{
				_owner.CurrentAttackCooldown.Value -= deltaTime;
			}
			else 
			{
				_owner.CurrentAttackCooldown.Value = _owner.MaxAttackCooldown.Value;
				_attack.Attack();
			}
		}

		public override void Exit()
		{
		}
	}
}