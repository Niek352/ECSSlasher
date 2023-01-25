using ClassLibrary1;
using ClassLibrary1.Enums;
using JCMG.EntitasRedux;
using Services.Camera;

namespace Ecs.Game.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 20, "Camera")]
	public class CameraBrainUpdateSystem : ILateUpdateSystem
	{
		private readonly ICameraProvider _cameraProvider;

		public CameraBrainUpdateSystem(ICameraProvider cameraProvider)
		{
			_cameraProvider = cameraProvider;
		}

		public void LateUpdate()
		{
			_cameraProvider.Update();
		}
	}
}