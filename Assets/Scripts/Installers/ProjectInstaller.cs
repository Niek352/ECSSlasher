using MessagePipe;
using VContainer;
using VContainer.Extensions;
using VContainerUi;
using VContainerUi.Services.Impl;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void Install(IContainerBuilder builder)
		{
			ConfigureMessagePipe(builder);
		}
		
		private void ConfigureMessagePipe(IContainerBuilder builder)
		{
			builder.Register<UiMessagesReceiverService>(Lifetime.Singleton)
				.AsImplementedInterfaces();
			
			builder.Register<UiMessagesPublisherService>(Lifetime.Singleton)
				.AsImplementedInterfaces();
            
			var options = builder.RegisterMessagePipe();
			RegisterMessages(builder, options);
           
			builder.RegisterBuildCallback(c 
				=> GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
		}
		
		private void RegisterMessages(IContainerBuilder builder, MessagePipeOptions options)
		{
			//throw new System.NotImplementedException();
			builder.RegisterUiSignals(options);
		}
	}
}