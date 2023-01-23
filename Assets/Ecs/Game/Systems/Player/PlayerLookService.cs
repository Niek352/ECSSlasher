using ClassLibrary1;
using ClassLibrary1.Enums;
using JCMG.EntitasRedux;
using Services.Input;
using UnityEngine;
using VContainer.Unity;

namespace Ecs.Game.Systems.Player
{
	[Install(ExecutionType.Game, ExecutionPriority.High, 5, "Input")]
	public class PlayerLookService : IUpdateSystem, IStartable
	{
		private readonly GameContext _game;
		private readonly IInputProvider _input;
		private  Camera _camera;
		
		public PlayerLookService(
			GameContext game,
			IInputProvider input
			)
		{
			_game = game;
			_input = input;
		}

		public void Update()
		{
			var playerEntity = _game.PlayerEntity;
			var dir = new Vector3(_input.MousePosition.x, _input.MousePosition.y) - _camera.WorldToScreenPoint(playerEntity.Position.Value);
			var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
			
			var resultRotation = Quaternion.RotateTowards(
				playerEntity.Rotation.Value, 
				Quaternion.AngleAxis(angle, Vector3.up), 
				Time.deltaTime * (360f * 1));
			
			playerEntity.ReplaceRotation(resultRotation);
		}
		
		public void Start()
		{
			_camera = Object.FindObjectOfType<Camera>();
		}
	}
}