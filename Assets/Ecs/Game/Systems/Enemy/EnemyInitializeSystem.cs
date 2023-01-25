using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary1.Enums;
using Enemy.StateMachine.States;
using JCMG.EntitasRedux;
using Services.StateMachineService;

namespace Ecs.Game.Systems.Enemy
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 20, "Enemy")]
	public class EnemyInitializeSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _game;
		private readonly IStateMachineService _stateMachineService;

		public EnemyInitializeSystem(GameContext game, 
			IStateMachineService stateMachineService
			) : base(game)
		{
			_game = game;
			_stateMachineService = stateMachineService;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.Enemy);

		protected override bool Filter(GameEntity entity)
			=> entity.IsEnemy && !entity.HasStateMachine && entity.HasEnemyModel;
		
		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				entity.AddTarget(_game.PlayerEntity);
				var stateMachine = _stateMachineService.GetStateMachine(entity.EnemyModel.Value.EnemyStateMachineBuilder, entity);
				stateMachine.Initialize<InitializeState>();
				entity.AddStateMachine(stateMachine);
			}
		}
	}
}