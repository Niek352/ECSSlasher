using Ui.Loose.Restart;
using VContainer;
using VContainerUi.Abstraction;

namespace Ui.Loose
{
	public class LooseWindow : WindowBase
	{
		public override string Name => nameof(LooseWindow);

		public LooseWindow(IObjectResolver container) : base(container)
		{
		}
		
		protected override void AddControllers()
		{
			AddController<RestartController>();
		}
	}
}