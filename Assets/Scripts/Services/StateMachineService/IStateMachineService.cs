using StateMachine;
using StateMachine.Abstract;

namespace Services.StateMachineService
{
	public interface IStateMachineService
	{
		AbstractStateMachine GetStateMachine(StateMachineBuilder stateMachineBuilder, GameEntity gameEntity);
	}
}