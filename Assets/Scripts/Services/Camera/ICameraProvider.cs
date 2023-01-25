using Cinemachine;
using UnityEngine;

namespace Services.Camera
{
	public interface ICameraProvider
	{
		UnityEngine.Camera Camera { get; set; }
		Transform Follow { get; set; }
		Transform LookAt { get; set; }
		void InitVirtualCamera(CinemachineVirtualCamera thirdPersonCamera);
		void InitCamera(UnityEngine.Camera camera, CinemachineBrain brain);
		void Update();
	}
}