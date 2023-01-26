using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
	[Game]
	[Unique]
	public class EnemyWaveComponent : IComponent
	{
		public int MaxEnemyCount;
	}
}