using JCMG.EntitasRedux;
using StateMachine.Interfaces;

namespace Ecs.Game.Components
{
	[Game]
	public class StateMachineComponent : IComponent
	{
		public IStateMachine Value;
	}
}