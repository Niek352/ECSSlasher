using JCMG.EntitasRedux;

namespace Ecs.Action.Components
{
	[Action]
	public class ProcessAttackComponent : IComponent
	{
		public ProcessAttackData AttackData;
	}

	public readonly struct ProcessAttackData
	{
		public readonly GameEntity Target;
		public readonly GameEntity Source;
		
		public ProcessAttackData(GameEntity source, GameEntity target)
		{
			Source = source;
			Target = target;
		}
	}
}