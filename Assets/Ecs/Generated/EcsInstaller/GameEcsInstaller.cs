//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ecs.Game.Systems.Initialize;
using Ecs.Action.Systems;
using Ecs.Game.Systems.Player;
using Ecs.Game.Systems;
using Ecs.Game.Systems.Enemy;
using Ecs.Game.Core.Systems;
using VContainer;

	public static class GameEcsInstaller
	{
		public static void InstallSystems(IContainerBuilder container)
		{
			container.Register<GameInitializeSystem>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            container.Register<CreateBulletSystem>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            container.Register<PlayerMoveService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            container.Register<BulletRayCastSystem>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            container.Register<CameraInitializeSystem>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            container.Register<CameraBrainUpdateSystem>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            container.Register<EnemyInitializeSystem>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            container.Register<PlayerLookService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            container.Register<StateMachineUpdateSystem>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            container.Register<ViewInstantiateSystem>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
		}
	}
