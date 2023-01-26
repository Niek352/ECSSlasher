using Interfaces;
using JCMG.EntitasRedux;
using Services.Camera;
using UnityEngine;
using VContainer;

namespace Ecs.Views.Linkable.Impl
{
	public class PlayerView : CharacterView, IEntityHitBox
	{
		[Inject] private readonly ICameraProvider _cameraProvider;
		
		public override void Link(IEntity entity, IContext context)
		{
			base.Link(entity, context);
			
			_cameraProvider.LookAt = transform;
			_cameraProvider.Follow = transform;
		}
		
		public void ApplyHit(ref RaycastHit hit, GameEntity bullet)
		{
			
		}
		
		public GameEntity GetEntity()
			=> Self;
	}
}