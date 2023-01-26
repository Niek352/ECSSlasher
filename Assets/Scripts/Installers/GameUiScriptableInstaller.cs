﻿using Ui.Hud;
using Ui.Hud.EnemyCounter;
using UnityEngine;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;
using VContainerUi;
using VContainerUi.Interfaces;
using VContainerUi.Model;

namespace Installers
{
	[CreateAssetMenu(menuName = "Settings/Installer/" + nameof(GameUiScriptableInstaller), fileName = nameof(GameUiScriptableInstaller))]
	public class GameUiScriptableInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private Canvas _canvas;
		[Space(10)]
		[SerializeField] private EnemyCounterView _counterView;
		
		public override void Install(IContainerBuilder builder)
		{
			var canvas = Instantiate(_canvas);
			builder.RegisterInstance(canvas);
			ConfigureWindowsController(builder);
			ConfigureWindows(builder);
			
			RegisterUiViews(builder, canvas);
		}
		
		private void RegisterUiViews(IContainerBuilder builder, Canvas canvas)
		{
			builder.RegisterUiView<EnemyCounterController, EnemyCounterView>(_counterView, canvas.transform);
		}
		
		private void ConfigureWindows(IContainerBuilder builder)
		{
			builder.Register<GameHUDWindow>(Lifetime.Singleton)
				.AsImplementedInterfaces().AsSelf();
		}
		
		private void ConfigureWindowsController(IContainerBuilder builder)
		{
			builder.Register<WindowState>(Lifetime.Singleton)
				.AsImplementedInterfaces()
				.AsSelf();

			builder.RegisterEntryPoint<WindowsController>().WithParameter(UiScope.Local);
		}
	}
}