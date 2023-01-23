using System;
using Ecs.Loop;
using JCMG.EntitasRedux;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace Installers
{
	public class EcsInstaller : MonoInstaller
	{
		private Contexts _contexts;

		public override void Install(IContainerBuilder builder)
		{
			_contexts = Contexts.SharedInstance;
			RegisterContext<GameContext>(builder);
			//BindContext<ActionContext>();
			
			InstallSystems(builder);
			
			RegisterEventSystem<GameEventSystems>(builder);
			
			RegisterFeature<Feature>(builder);
			
			builder.RegisterInstance(_contexts);
			builder.RegisterEntryPoint<EcsLoop>();
		}
		
		private void InstallSystems(IContainerBuilder builder)
		{
			GameEcsInstaller.InstallSystems(builder);
		}
		
		private void RegisterEventSystem<TEventSystem>(IContainerBuilder containerBuilder)
			where TEventSystem : Feature
		{
			//Container.BindInterfacesTo<TEventSystem>().AsSingle().WithArguments(_contexts);
			containerBuilder.Register<TEventSystem>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(_contexts);
		}
		
		private void RegisterContext<TContext>(IContainerBuilder containerBuilder)
			where TContext : IContext
		{
			foreach (var ctx in _contexts.AllContexts)
				if (ctx is TContext context)
				{
					//Container.BindInterfacesAndSelfTo<TContext>().FromInstance(context).AsSingle();
					containerBuilder.RegisterInstance(context).AsImplementedInterfaces().AsSelf();
					return;
				}

			throw new Exception($"[{nameof(EcsInstaller)}] No context with type: {typeof(TContext).Name}");
		}

		private void RegisterFeature<TFeature>(IContainerBuilder containerBuilder)
			where TFeature : Feature, new()
		{
			var mainFeature = new TFeature();
			//Container.Bind<TFeature>().FromInstance(mainFeature);
			containerBuilder.RegisterInstance(mainFeature);
		}
	}
}