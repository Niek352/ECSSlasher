using System;
using System.Collections.Generic;
using JCMG.EntitasRedux;
using Services.CameraProvider;
using UnityEngine;
using UnityEngine.Pool;
using VContainer.Unity;
using VContainerUi.Abstraction;
using Object = UnityEngine.Object;

namespace Ui.Hud.HealthDrawer
{
	public class HealthDrawerController : UiController<HealthDrawerView>, ITickable, IStartable, IDisposable
	{
		private readonly GameContext _game;
		private readonly ICameraProvider _cameraProvider;
		private readonly Dictionary<IEntity, HealthItem> _entities = new Dictionary<IEntity, HealthItem>();
		private readonly IGroup<GameEntity> _group;

		public HealthDrawerController(
			GameContext game,
			ICameraProvider cameraProvider)
		{
			_game = game;
			_cameraProvider = cameraProvider;
			_group = _game.GetGroup(GameMatcher.Health);
		}
		
		public void Tick()
		{
			foreach (var item in _entities.Values)
			{
				var screenPoint = RectTransformUtility.WorldToScreenPoint(_cameraProvider.Camera, item.OwnedEntity.Position.Value);
				item.HealthBar.transform.position = screenPoint + new Vector2(0,50);
			}
		}

		public void Start()
		{
			var buffer = ListPool<GameEntity>.Get();
			_group.GetEntities(buffer);
			foreach (var entity in buffer)
			{
				OnEntityCreated(_game, entity);
			}
			ListPool<GameEntity>.Release(buffer);
			
			_game.OnEntityCreated += OnEntityCreated;
			_game.OnEntityWillBeDestroyed += OnEntityDestroyed;
		}
		
		private void OnEntityDestroyed(IContext context, IEntity entity)
		{
			if (!_entities.ContainsKey(entity))
				return;
			
			var healthItem = _entities[entity];
			Object.Destroy(healthItem.HealthBar);
			_entities.Remove(entity);
		}

		private void OnEntityCreated(IContext context, IEntity entity)
		{
			var e = (GameEntity)entity;
			if (!e.HasHealth || !e.IsPlayer)
				return;
			var hpBar = Object.Instantiate(View.HpBarPrefab, View.transform);
			e.AddHealthAddedListener(hpBar);
			_entities.Add(entity, new HealthItem(hpBar, e));
		}
		
		public void Dispose()
		{
			_game.OnEntityCreated -= OnEntityCreated;
			_game.OnEntityWillBeDestroyed -= OnEntityDestroyed;
		}
	}
}