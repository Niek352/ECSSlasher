using Cinemachine;
using JCMG.EntitasRedux;
using Services.Camera;
using UnityEngine;
using VContainer;

namespace Ecs.Views.Linkable.Impl
{
	public class VirtualCameraView : ObjectView
	{
		[SerializeField] private CinemachineVirtualCamera _thirdPersonCamera;

		[Inject] private readonly GameContext _game;
		[Inject] private readonly ICameraProvider _cameraProvider;
		
		public override void Link(IEntity entity, IContext context)
		{
			base.Link(entity, context);
			_cameraProvider.InitVirtualCamera(_thirdPersonCamera);
		}
	}
}