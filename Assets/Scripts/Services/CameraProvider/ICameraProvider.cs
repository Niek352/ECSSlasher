using Cinemachine;
using UnityEngine;

namespace Services.CameraProvider
{
	public interface ICameraProvider
	{
		Camera Camera { get; set; }
		Transform Follow { get; set; }
		Transform LookAt { get; set; }
		void InitVirtualCamera(CinemachineVirtualCamera thirdPersonCamera);
		void InitCamera(Camera camera, CinemachineBrain brain);
		void Update();
	}
}