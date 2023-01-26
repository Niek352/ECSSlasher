using ClassLibrary1;
using ClassLibrary1.Enums;
using Db.EnemyData;
using Db.PlayerData;
using Ecs.Game.Extensions;
using JCMG.EntitasRedux;
using Model.Enemy;
using UnityEngine;

namespace Ecs.Game.Systems.Initialize
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 0)]
	public class GameInitializeSystem : IInitializeSystem
	{
		private readonly GameContext _game;
		private readonly IEnemyData _enemyData;
		private readonly IPlayerData _playerData;

		public GameInitializeSystem(
			GameContext game,
			IEnemyData enemyData,
			IPlayerData playerData)
		{
			_game = game;
			_enemyData = enemyData;
			_playerData = playerData;
		}
		
		public void Initialize()
		{
			_game.CreatePlayer(_playerData.PlayerModel, Vector3.zero);
			_game.CreateEnemy(_enemyData.GetEnemy(EnemyType.Warrior), new Vector3(0,0,2));
		}
	}
}