using ClassLibrary1;
using ClassLibrary1.Enums;
using JCMG.EntitasRedux;
using UnityEngine;
using UnityEngine.Pool;

namespace Ecs.Game.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 30, "StateMachine")]
	public class StateMachineUpdateSystem : IUpdateSystem
	{
		private readonly IGroup<GameEntity> _stateMachineGroup;

		public StateMachineUpdateSystem(GameContext game)
		{
			_stateMachineGroup = game.GetGroup(GameMatcher.StateMachine);
		}
		
		public void Update()
		{
			var gameEntities = ListPool<GameEntity>.Get();
			_stateMachineGroup.GetEntities(gameEntities);
			var deltaTime = Time.deltaTime;
			
			foreach (var entity in gameEntities)
			{
				entity.StateMachine.Value.Update(deltaTime);
			}

			ListPool<GameEntity>.Release(gameEntities);
		}
	}
}