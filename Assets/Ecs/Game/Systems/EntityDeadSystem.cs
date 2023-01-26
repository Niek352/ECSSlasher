using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary1.Enums;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 102)]
	public class EntityDeadSystem : ReactiveSystem<GameEntity>
	{
		public EntityDeadSystem(IContext<GameEntity> context) : base(context)
		{
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
		}

		private void PlayerDead(GameEntity entity)
		{
			
		}
	}
}