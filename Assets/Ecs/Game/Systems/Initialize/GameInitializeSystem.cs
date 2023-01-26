using ClassLibrary1;
using ClassLibrary1.Enums;
using Db.PlayerData;
using Ecs.Game.Extensions;
using JCMG.EntitasRedux;
using MessagePipe;
using Ui.Hud;
using UnityEngine;
using VContainerUi.Messages;

namespace Ecs.Game.Systems.Initialize
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 0)]
	public class GameInitializeSystem : IInitializeSystem
	{
		private readonly GameContext _game;
		private readonly IPlayerData _playerData;
		private readonly IPublisher<MessageOpenWindow> _openWindow;

		public GameInitializeSystem(
			GameContext game,
			IPlayerData playerData,
			IPublisher<MessageOpenWindow> openWindow)
		{
			_game = game;
			_playerData = playerData;
			_openWindow = openWindow;
		}
		
		public void Initialize()
		{
			_game.CreatePlayer(_playerData.PlayerModel, Vector3.zero);
			_game.CreateEnemyWave();
			_openWindow.Publish(new MessageOpenWindow(typeof(GameHUDWindow)));
		}
	}
}