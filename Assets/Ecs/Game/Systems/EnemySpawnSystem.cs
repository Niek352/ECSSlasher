using ClassLibrary1;
using ClassLibrary1.Enums;
using Db.EnemyData;
using Ecs.Game.Extensions;
using JCMG.EntitasRedux;
using Model.Enemy;
using Services;
using UnityEngine;

namespace Ecs.Game.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 120, "Enemy")]
	public class EnemySpawnSystem : IUpdateSystem
	{
		private readonly GameContext _game;
		private readonly IEnemyData _enemyData;
		private readonly IEnemySpawnPointService _enemySpawnPointService;

		public EnemySpawnSystem(
			GameContext game,
			IEnemyData enemyData,
			IEnemySpawnPointService enemySpawnPointService)
		{
			_game = game;
			_enemyData = enemyData;
			_enemySpawnPointService = enemySpawnPointService;
		}
		
		public void Update()
		{
			if(!_game.HasEnemyWave)
				return;
			
			var enemyWave = _game.EnemyWaveEntity;
			var enemies = _game.GetEntitiesWithCharacterId(0);
			if (enemyWave.Cooldown.Value < enemyWave.MaxCooldown.Value && enemies.Count < enemyWave.EnemyWave.MaxEnemyCount)
			{
				CreateEnemy();
				enemyWave.Cooldown.Value = enemyWave.MaxCooldown.Value;
			}
			else
			{
				enemyWave.Cooldown.Value -= Time.deltaTime;
			}
		}

		private void CreateEnemy()
		{
			_game.CreateEnemy(_enemyData.GetEnemy((EnemyType)Random.Range(0,2)), 
				_enemySpawnPointService.GetEnemySpawnPoint() + _game.PlayerEntity.Position.Value);
		}
	}
}