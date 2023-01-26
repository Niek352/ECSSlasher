using Ui.Hud.EnemyCounter;
using VContainer;
using VContainerUi.Abstraction;

namespace Ui.Hud
{
	public class GameHUDWindow : WindowBase
	{
		public GameHUDWindow(IObjectResolver container) : base(container)
		{
		}
		
		public override string Name => nameof(GameHUDWindow);
		
		protected override void AddControllers()
		{
			AddController<EnemyCounterController>();	
		}
	}
}