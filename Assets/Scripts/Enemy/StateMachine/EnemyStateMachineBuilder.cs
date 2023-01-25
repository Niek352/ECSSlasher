using System;
using Enemy.Attack.Abstract;
using Enemy.Attack.Impl;
using Enemy.Movement.Abstract;
using Enemy.Movement.Impl;
using Enemy.StateMachine.States.Movement;
using Model.Enemy;
using StateMachine;
using StateMachine.Abstract;
using UnityEngine;
using VContainer;

namespace Enemy.StateMachine
{
	[CreateAssetMenu(menuName = "Settings/SM/" + nameof(EnemyStateMachineBuilder), fileName = nameof(EnemyStateMachineBuilder))]
	public class EnemyStateMachineBuilder : StateMachineBuilder
	{
		[Inject] private readonly GameContext _gameContext;
		[Inject] private readonly ActionContext _actionContext;
		
		public override AbstractStateMachine Create(GameEntity owner)
		{
			return new EnemyStateMachine(owner, CreateAttack(owner.EnemyModel.Value, owner), CreateMovement(owner.EnemyModel.Value, owner));
		}

		private AbstractAttack CreateAttack(EnemyModel enemyModel, GameEntity owner) => enemyModel.EnemyAttackType switch
		{
			EnemyAttackType.Melee => new MeleeAttack(owner, _actionContext, _gameContext),
			EnemyAttackType.Range => new RangeAttack(owner, _actionContext),
			_ => throw new ArgumentOutOfRangeException(nameof(enemyModel.EnemyAttackType), enemyModel.EnemyAttackType, null)
		};

		private AbstractMovement CreateMovement(EnemyModel enemyModel, GameEntity owner) => enemyModel.EnemyMovementType switch
		{
			EnemyMovementType.SimpleMovement => new SimpleEnemyMovement(owner),
			_ => throw new ArgumentOutOfRangeException(nameof(enemyModel.EnemyMovementType), enemyModel.EnemyMovementType, null)
		};
	}
}