using System;
using Db.ViewData;
using Ecs.Views.Linkable;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Ecs.Factories.View.Impl
{
	public class ViewFactory : IViewFactory<GameEntity, ILinkable>
	{
		private readonly IObjectResolver _resolver;
		private readonly IViewData _viewData;

		public ViewFactory(
			IObjectResolver resolver,
			IViewData viewData
			)
		{
			_resolver = resolver;
			_viewData = viewData;
		}
		
		public ILinkable Create(GameEntity entity)
		{
			if (!entity.HasPrefab)
				throw new ArgumentOutOfRangeException(nameof(entity), entity, "entity hasn't prefab component, it cannot be spawned");

			var viewPrefab = _viewData.Get(entity.Prefab.PrefabName);
			var position = entity.HasPosition ? entity.Position.Value : Vector3.zero;
			var obj = _resolver.Instantiate(viewPrefab, position, Quaternion.identity);
			
			return obj;
		}
	}
}