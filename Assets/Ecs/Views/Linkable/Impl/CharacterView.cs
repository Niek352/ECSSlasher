using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
	public class CharacterView : ObjectView, IVelocityAddedListener
	{
		[SerializeField] private CharacterController _characterController;

		protected GameEntity Self;

		public override void Link(IEntity entity, IContext context)
		{
			base.Link(entity, context);
			
			Self = (GameEntity)entity;
			Self.AddVelocityAddedListener(this);
			Self.AddCharacterController(_characterController);
		}

		public void OnVelocityAdded(GameEntity entity, Vector3 value)
		{
			_characterController.Move(value);
			Self.ReplacePosition(transform.position);
		}
	}
}