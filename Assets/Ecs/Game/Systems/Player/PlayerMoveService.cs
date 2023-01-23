using ClassLibrary1;
using ClassLibrary1.Enums;
using Db.PlayerData;
using JCMG.EntitasRedux;
using Services.Input;
using UnityEngine;

namespace Ecs.Game.Systems.Player
{
	[Install(ExecutionType.Game, ExecutionPriority.High, 6, "Input")]
	public class PlayerMoveService : IUpdateSystem
	{
		private readonly IInputProvider _input;
		private readonly GameContext _game;
		private readonly IPlayerData _playerData;

		public PlayerMoveService(
			GameContext game,
			IInputProvider input,
			IPlayerData playerData)
		{
			_input = input;
			_game = game;
			_playerData = playerData;
		}

		public void Update()
		{
			var moveInput = _input.MoveValue * _playerData.MoveSpeed;
			var newVelocity = (_game.PlayerEntity.Velocity.Value + new Vector3(moveInput.x, 0, moveInput.y)) * Time.deltaTime;
			_game.PlayerEntity.ReplaceVelocity(newVelocity); 
		}
	}

}