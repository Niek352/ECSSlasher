using ClassLibrary1;
using ClassLibrary1.Enums;
using Db.PlayerData;
using JCMG.EntitasRedux;
using Services.Input;
using UnityEngine;

namespace Ecs.Game.Systems.Player
{
	[Install(ExecutionType.Game, ExecutionPriority.High, 6, "Input")]
	public class PlayerMoveSystem : IUpdateSystem
	{
		private readonly IInputProvider _input;
		private readonly GameContext _game;

		public PlayerMoveSystem(
			GameContext game,
			IInputProvider input)
		{
			_input = input;
			_game = game;
		}

		public void Update()
		{
			var playerEntity = _game.PlayerEntity;
			var moveInput = _input.MoveValue * playerEntity.MoveSpeed.Value;
			var newVelocity = (playerEntity.Velocity.Value + new Vector3(moveInput.x, 0, moveInput.y)) * Time.deltaTime;
			playerEntity.ReplaceVelocity(newVelocity); 
		}
	}

}