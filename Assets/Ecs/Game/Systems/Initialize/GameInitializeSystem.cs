using ClassLibrary1;
using ClassLibrary1.Enums;
using Db.EnemyData;
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

		public GameInitializeSystem(
			GameContext game,
			IEnemyData enemyData)
		{
			_game = game;
			_enemyData = enemyData;
		}
		
		public void Initialize()
		{
			_game.CreatePlayer(Vector3.zero);
			_game.CreateEnemy(_enemyData.GetEnemy(EnemyType.Warrior), Vector3.zero);
		}
	}
}