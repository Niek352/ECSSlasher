using Ecs.Factories.View.Impl;
using Services.Input.Impl;
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
		}
	}
}