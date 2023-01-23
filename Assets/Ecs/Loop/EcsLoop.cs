using System;
using System.Collections.Generic;
using JCMG.EntitasRedux;
using VContainer.Unity;

namespace Ecs.Loop
{
	public class EcsLoop : IInitializable, ITickable, ILateTickable, IFixedTickable, IDisposable
	{
		private readonly Contexts _contexts;
		private readonly Feature _feature;
		private bool _isInitialized;
		private bool _isPaused;

		public EcsLoop(
			Feature feature,
			Contexts contexts,
			IEnumerable<ISystem> systems
		)
		{
			_contexts = contexts;
			_feature = feature;
			foreach (var t in systems)
			{
				_feature.Add(t);
			}
		}
		
		public void Initialize()
		{
			if (_isInitialized)
				throw new Exception($"[{nameof(EcsLoop)}] EcsLoop already is initialized");
		
			_feature.Initialize();
			_isInitialized = true;
		}

		public void Tick()
		{
			if (_isPaused)
				return;

			_feature.Update();
			_feature.Execute();
		}

		public void FixedTick()
		{
			if (_isPaused)
				return;

			_feature.FixedUpdate();
		}


		public void LateTick()
		{
			if (_isPaused)
				return;

			
			_feature.LateUpdate();
			_feature.Cleanup();
		}


		public void Pause(bool isPaused)
		{
			_isPaused = isPaused;
		}

		public void Reset()
		{
			Pause(true);

			_feature.Deactivate();
			foreach (var context in _contexts.AllContexts)
			{
				context.DestroyAllEntities();
				context.ResetCreationIndex();
			}

			_feature.Activate();
			_isInitialized = false;
			Initialize();

			Pause(false);
		}

		public void Dispose()
		{
			_feature.Deactivate();
			_contexts.Reset();
		}
	}
}