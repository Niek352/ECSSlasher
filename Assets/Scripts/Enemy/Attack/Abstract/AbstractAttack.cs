using Model.Enemy;

namespace Enemy.Attack.Abstract
{
	public abstract class AbstractAttack
	{
		public abstract EnemyAttackType EnemyAttackType { get; }
		public abstract bool InCoolDown { get; }
		public abstract void Attack();
	}
}