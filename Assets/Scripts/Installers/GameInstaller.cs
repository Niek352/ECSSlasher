﻿using Ecs.Factories.View.Impl;
using Services;
using Services.CameraProvider.Impl;
using Services.Input.Impl;
using Services.StateMachineService.Impl;
using Services.Statistic.Impl;
using VContainer;
using VContainer.Extensions;

namespace Installers
{
	public class GameInstaller : MonoInstaller
	{
		public override void Install(IContainerBuilder builder)
		{
			builder.Register<ViewFactory>(Lifetime.Singleton).AsImplementedInterfaces();
			builder.Register<InputProvider>(Lifetime.Singleton).AsImplementedInterfaces();
			builder.Register<PlayerCameraProvider>(Lifetime.Singleton).AsImplementedInterfaces();
			builder.Register<StateMachineService>(Lifetime.Singleton).AsImplementedInterfaces();
			builder.Register<StatisticService>(Lifetime.Singleton).AsImplementedInterfaces();
			builder.Register<EnemySpawnPointService>(Lifetime.Singleton).AsImplementedInterfaces();
		}
	}
}