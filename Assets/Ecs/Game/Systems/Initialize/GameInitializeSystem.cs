using ClassLibrary1;
using ClassLibrary1.Enums;
using Ecs.Game.Extensions;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Systems.Initialize
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 0)]
	public class GameInitializeSystem : IInitializeSystem
	{
		private readonly GameContext _game;

		public GameInitializeSystem(GameContext game)
		{
			_game = game;
		}
		
		public void Initialize()
		{
			_game.CreatePlayer(Vector3.zero);
		}
	}
}