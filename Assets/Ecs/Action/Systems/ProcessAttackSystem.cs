using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary1.Enums;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 100, "")]
	public class ProcessAttackSystem : ReactiveSystem<ActionEntity>
	{
		public ProcessAttackSystem(ActionContext action) : base(action)
		{
			
		}

		protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> action)
			=> action.CreateCollector(ActionMatcher.ProcessAttack);

		protected override bool Filter(ActionEntity entity)
			=> entity.HasProcessAttack;
		
		protected override void Execute(List<ActionEntity> entities)
		{
			foreach (var actionEntity in entities)
			{
				var attackSource = actionEntity.ProcessAttack.AttackData.Source;
				var attackTarget = actionEntity.ProcessAttack.AttackData.Target;
				ProcessAttack(attackSource, attackTarget);
				
				actionEntity.Destroy();
			}
		}

		private void ProcessAttack(GameEntity source, GameEntity target)
		{
			target.Health.Value -= source.Damage.Value * (1 - target.Defence.Value);
			target.ReplaceHealth(Mathf.Clamp(target.Health.Value, 0, target.MaxHealth.Value)); 

			if (target.Health.Value == 0 && !target.IsDead)
			{
				target.IsDead = true;
			}
		}
	}
}