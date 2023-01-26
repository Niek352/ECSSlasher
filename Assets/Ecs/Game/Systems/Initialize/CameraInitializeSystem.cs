using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary1.Enums;
using Ecs.Game.Extensions;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Initialize
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 15, "Camera")]
	public class CameraInitializeSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _game;

		public CameraInitializeSystem(GameContext game) : base(game)
		{
			_game = game;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.Player);
		
		protected override bool Filter(GameEntity entity)
			=> entity.IsPlayer;
		
		protected override void Execute(List<GameEntity> entities)
		{
			_game.CreateCamera();
			_game.CreateVirtualCamera();
		}
	}
}