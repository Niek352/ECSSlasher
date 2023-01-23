using Ecs.Factories.View.Impl;
using VContainer;
using VContainer.Extensions;

namespace Installers
{
	public class GameInstaller : MonoInstaller
	{
		public override void Install(IContainerBuilder builder)
		{
			builder.Register<ViewFactory>(Lifetime.Singleton).AsImplementedInterfaces();
		}
	}
}