using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
	public class CharacterView : ObjectView, IVelocityAddedListener
	{
		[SerializeField] private CharacterController _characterController;
		
		private GameEntity _self;

		public override void Link(IEntity entity, IContext context)
		{
			base.Link(entity, context);
			
			_self = (GameEntity)entity;
			_self.AddVelocityAddedListener(this);
			_self.AddCharacterController(_characterController);
		}

		public void OnVelocityAdded(GameEntity entity, Vector3 value)
		{
			_characterController.Move(value);
			_self.ReplacePosition(transform.position);
		}
	}
}