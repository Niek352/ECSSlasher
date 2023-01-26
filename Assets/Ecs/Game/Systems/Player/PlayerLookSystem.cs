using ClassLibrary1;
using ClassLibrary1.Enums;
using JCMG.EntitasRedux;
using Services.CameraProvider;
using Services.Input;
using UnityEngine;

namespace Ecs.Game.Systems.Player
{
	[Install(ExecutionType.Game, ExecutionPriority.Low, 25, "Input")]
	public class PlayerLookSystem : IUpdateSystem
	{
		private readonly GameContext _game;
		private readonly IInputProvider _input;
		private readonly ICameraProvider _cameraProvider;
		
		public PlayerLookSystem(
			GameContext game,
			IInputProvider input,
			ICameraProvider cameraProvider
			)
		{
			_game = game;
			_input = input;
			_cameraProvider = cameraProvider;
		}

		public void Update()
		{
			if (!_cameraProvider.Camera)
				return;
			var playerEntity = _game.PlayerEntity;
			var dir = new Vector3(_input.MousePosition.x, _input.MousePosition.y) - _cameraProvider.Camera.WorldToScreenPoint(playerEntity.Position.Value);
			var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
			
			var resultRotation = Quaternion.RotateTowards(
				playerEntity.Rotation.Value, 
				Quaternion.AngleAxis(angle, Vector3.up), 
				Time.deltaTime * (360f * 1));
			
			playerEntity.ReplaceRotation(resultRotation);
		}
	}
}