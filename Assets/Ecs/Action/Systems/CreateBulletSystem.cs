using System;
using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary1.Enums;
using Ecs.Game.Extensions;
using JCMG.EntitasRedux;
using Services.Input;
using UniRx;
using UnityEngine;

namespace Ecs.Action.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 1, "")]
	public class CreateBulletSystem : ReactiveSystem<ActionEntity>, IDisposable
	{
		private readonly ActionContext _action;
		private readonly GameContext _game;
		private readonly IDisposable _inp;

		public CreateBulletSystem(
			ActionContext action,
			GameContext game,
			IInputProvider inputProvider) : base(action)
		{
			_action = action;
			_game = game;
			_inp = inputProvider.OnFireCommand.Subscribe(OnBull);
		}
		
		private void OnBull(Unit obj)
		{
			var playerEntity = _game.PlayerEntity;
			_action.CreateEntity().AddCreateBullet(playerEntity.Position.Value, playerEntity.Transform.Value.forward * 10);
		}

		protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context)
			=> context.CreateCollector(ActionMatcher.CreateBullet);
		
		protected override bool Filter(ActionEntity entity)
			=> entity.HasCreateBullet;
		
		protected override void Execute(List<ActionEntity> entities)
		{
			foreach (var entity in entities)
			{
				_game.CreateBullet(entity.CreateBullet.SpawnPoint, entity.CreateBullet.Velocity);
				entity.Destroy();
			}
		}
		public void Dispose()
		{
			_inp?.Dispose();
		}
	}
}