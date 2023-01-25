using System.Collections.Generic;
using StateMachine;
using StateMachine.Abstract;
using StateMachine.Interfaces;
using VContainer;

namespace Services.StateMachineService.Impl
{
	public class StateMachineService : IStateMachineService
	{
		private readonly IObjectResolver _resolver;
		private readonly HashSet<StateMachineBuilder> _stateMachines = new HashSet<StateMachineBuilder>();
		
		public StateMachineService(IObjectResolver resolver)
		{
			_resolver = resolver;
		}

		public AbstractStateMachine GetStateMachine(StateMachineBuilder stateMachineBuilder, GameEntity gameEntity)
		{
			TryInject(stateMachineBuilder);

			var result =  stateMachineBuilder.Create(gameEntity);
			return result;
		}

		private void TryInject(StateMachineBuilder stateMachineBuilder)
		{
			if (!_stateMachines.Contains(stateMachineBuilder))
			{
				_resolver.Inject(stateMachineBuilder);
				_stateMachines.Add(stateMachineBuilder);
			}
		}
	}
}