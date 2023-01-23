using ClassLibrary1;
using ClassLibrary1.Enums;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 1, "test") ]
	public class TestSystem : IUpdateSystem
	{
		public void Update()
		{
		}
	}
}