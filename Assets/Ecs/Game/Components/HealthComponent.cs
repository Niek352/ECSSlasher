using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
	[Game]
	public class HealthComponent : IComponent
	{
		public float Value;
	}
	
	[Game]
	public class DefenceComponent : IComponent
	{
		public float Value;
	}
}