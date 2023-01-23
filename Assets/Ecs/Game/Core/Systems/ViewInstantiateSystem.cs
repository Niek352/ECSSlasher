using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary1.Enums;
using Ecs.Factories.View;
using Ecs.Views.Linkable;
using JCMG.EntitasRedux;

namespace Ecs.Game.Core.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 500, "")]
	public class ViewInstantiateSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _game ;
		private readonly IViewFactory<GameEntity, ILinkable> _viewFactory;

		public ViewInstantiateSystem(
			GameContext game,
			IViewFactory<GameEntity, ILinkable> viewFactory
				) 
			: base(game)
		{
			_game = game;
			_viewFactory = viewFactory;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.Instantiate.Added());

		protected override bool Filter(GameEntity entity) 
			=> entity.IsInstantiate && entity.HasPrefab;
		
		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				var linkable = _viewFactory.Create(entity);
				if (linkable == null)
					continue;

				linkable.Link(entity, _game);
				entity.ReplaceLink(linkable);
			}
		}
	}
}