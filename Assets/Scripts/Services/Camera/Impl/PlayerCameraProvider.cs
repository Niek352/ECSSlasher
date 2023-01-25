using Cinemachine;
using UnityEngine;

namespace Services.Camera.Impl
{
	public class PlayerCameraProvider : ICameraProvider
	{
		private CinemachineVirtualCamera _thirdPersonCamera;
		private CinemachineBrain _brain;

		public UnityEngine.Camera Camera { get; set; }
		public Transform Follow { get; set; }
		public Transform LookAt { get; set; }
		
		public void InitVirtualCamera(CinemachineVirtualCamera thirdPersonCamera)
		{
			_thirdPersonCamera = thirdPersonCamera;
			_thirdPersonCamera.Follow = Follow;
			_thirdPersonCamera.LookAt = LookAt;
		}
		
		public void InitCamera(UnityEngine.Camera camera, CinemachineBrain brain)
		{
			Camera = camera;
			_brain = brain;
		}

		public void Update()
		{
			_brain.ManualUpdate();
		}
	}
}