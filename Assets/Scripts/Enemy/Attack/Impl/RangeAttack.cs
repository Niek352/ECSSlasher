﻿using Enemy.Attack.Abstract;
using Model.Enemy;
using UnityEngine;

namespace Enemy.Attack.Impl
{
	public class RangeAttack : AbstractAttack
	{
		private readonly GameEntity _owner;
		private readonly ActionContext _action;

		public override EnemyAttackType EnemyAttackType => EnemyAttackType.Range;
		public override bool InCoolDown => _owner.CurrentAttackCooldown.Value > 0;
		
		public RangeAttack(GameEntity owner, ActionContext action)
		{
			_owner = owner;
			_action = action;
		}
		
		public override void Attack()
		{
			_action.CreateEntity().AddCreateBullet(
				_owner.Position.Value, 
				_owner.Rotation.Value.eulerAngles * 5);
		}
	}
}