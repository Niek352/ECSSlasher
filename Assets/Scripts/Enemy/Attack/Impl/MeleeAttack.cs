using Ecs.Action.Components;
using Enemy.Attack.Abstract;
using Model.Enemy;

namespace Enemy.Attack.Impl
{
	public class MeleeAttack : AbstractAttack
	{
		private readonly GameEntity _owner;
		private readonly ActionContext _actionContext;
		private readonly GameContext _gameContext;
		public override EnemyAttackType EnemyAttackType => EnemyAttackType.Melee;
		public override bool InCoolDown => _owner.CurrentAttackCooldown.Value > 0;

		public MeleeAttack(GameEntity owner, ActionContext actionContext, GameContext gameContext)
		{
			_owner = owner;
			_actionContext = actionContext;
			_gameContext = gameContext;
		}
		
		public override void Attack()
		{
			_actionContext.CreateEntity().AddProcessAttack(new ProcessAttackData(_owner, _gameContext.PlayerEntity));
		}
	}
}