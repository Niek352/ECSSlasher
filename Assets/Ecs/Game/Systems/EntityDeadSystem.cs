using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary1.Enums;
using JCMG.EntitasRedux;
using MessagePipe;
using Services.Statistic;
using Ui.Loose;
using VContainerUi.Messages;

namespace Ecs.Game.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 102)]
	public class EntityDeadSystem : ReactiveSystem<GameEntity>
	{
		private readonly IStatisticService _statistic;
		private readonly IPublisher<MessageOpenWindow> _openWindow;
		
		public EntityDeadSystem(
			GameContext game,
			IStatisticService statistic,
			IPublisher<MessageOpenWindow> openWindow) : base(game)
		{
			_statistic = statistic;
			_openWindow = openWindow;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> game)
			=> game.CreateCollector(GameMatcher.Dead);

		protected override bool Filter(GameEntity entity)
			=> entity.IsDead;
		
		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				if (entity.IsPlayer)
				{
					PlayerDead(entity);
				}
				else if (entity.IsEnemy)
				{
					EnemyDead(entity);
				}
			}
		}
		
		private void EnemyDead(GameEntity entity)
		{
			entity.Destroy();
			_statistic.NumberKilledEnemies.Value++;
		}

		private void PlayerDead(GameEntity entity)
		{
			_openWindow.Publish(new MessageOpenWindow(typeof(LooseWindow)));
			entity.MoveSpeed.Value = 0;
		}
	}
}