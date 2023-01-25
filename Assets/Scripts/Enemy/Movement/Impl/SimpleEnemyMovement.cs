using Enemy.Movement.Abstract;
using UnityEngine;

namespace Enemy.Movement.Impl
{
	public class SimpleEnemyMovement : AbstractMovement
	{
		private readonly GameEntity _owner;
		private readonly GameEntity _playerEntity;
		public override bool ReachedTarget => Vector3.Distance(_owner.Position.Value, _playerEntity.Position.Value) < _owner.AttackRange.Value;

		public SimpleEnemyMovement(GameEntity owner)
		{
			_owner = owner;
			_playerEntity = owner.Target.Value;
		}
		
		public override void Move(float deltaTime)
		{
			var ownPosition = _owner.Position.Value;
			var dir = (_playerEntity.Position.Value - ownPosition).normalized;
			var velocity = dir * _owner.MoveSpeed.Value * deltaTime;
		
			_owner.ReplaceVelocity(velocity);
			_owner.ReplaceRotation(Quaternion.AngleAxis(Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, Vector3.up));
		}
	}
}