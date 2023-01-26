using System;
using Enemy.StateMachine;
using Enemy.StateMachine.States.Movement;
using Model.Character;
using UnityEngine;

namespace Model.Enemy
{
	[Serializable]
	public class EnemyModel : CharacterModel, IMoveModel, IAttackModel
	{
		[field:SerializeField] public float MoveSpeed { get; set; }
		[field:SerializeField] public float Damage { get; set; }
		[field:SerializeField] public float AttackCooldown { get; set; }
		
		public EnemyType EnemyType;
		public EnemyAttackType EnemyAttackType;
		public EnemyMovementType EnemyMovementType;
		public LayerMask BulletLayerMask;
		public float AttackRange;

		public EnemyStateMachineBuilder EnemyStateMachineBuilder;
	}

}