using Interfaces;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
	public class EnemyView : CharacterView, IEntityHitBox
	{
		public override void Link(IEntity entity, IContext context)
		{
			base.Link(entity, context);
		}
		
		public void ApplyHit(ref RaycastHit hit, GameEntity bullet)
		{
		}
		public GameEntity GetEntity()
			=> Self;
	}
}