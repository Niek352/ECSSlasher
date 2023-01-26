using System.Threading;
using ClassLibrary1;
using ClassLibrary1.Enums;
using Cysharp.Threading.Tasks;
using Db.EnemyData;
using Db.PlayerData;
using Ecs.Game.Extensions;
using JCMG.EntitasRedux;
using MessagePipe;
using Model.Enemy;
using Ui.Hud;
using UnityEngine;
using VContainer.Unity;
using VContainerUi.Messages;

namespace Ecs.Game.Systems.Initialize
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 0)]
	public class GameInitializeSystem : IInitializeSystem
	{
		private readonly GameContext _game;
		private readonly IEnemyData _enemyData;
		private readonly IPlayerData _playerData;
		private readonly IPublisher<MessageOpenWindow> _openWindow;

		public GameInitializeSystem(
			GameContext game,
			IEnemyData enemyData,
			IPlayerData playerData,
			IPublisher<MessageOpenWindow> openWindow)
		{
			_game = game;
			_enemyData = enemyData;
			_playerData = playerData;
			_openWindow = openWindow;
		}
		
		public void Initialize()
		{
			_game.CreatePlayer(_playerData.PlayerModel, Vector3.zero);
			_game.CreateEnemy(_enemyData.GetEnemy(EnemyType.Warrior), new Vector3(0,0,2));
			_openWindow.Publish(new MessageOpenWindow(typeof(GameHUDWindow)));
		}
	}
}