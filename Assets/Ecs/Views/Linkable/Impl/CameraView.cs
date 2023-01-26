using Cinemachine;
using JCMG.EntitasRedux;
using Services.CameraProvider;
using UnityEngine;
using VContainer;

namespace Ecs.Views.Linkable.Impl
{
	public class CameraView : ObjectView
	{
		[SerializeField] private Camera _camera;
		[SerializeField] private CinemachineBrain _brain;
		
		[Inject] private readonly ICameraProvider _cameraHolder;

		public override void Link(IEntity entity, IContext context)
		{
			_cameraHolder.InitCamera(_camera, _brain);
			
			base.Link(entity, context);
		}
	}
}