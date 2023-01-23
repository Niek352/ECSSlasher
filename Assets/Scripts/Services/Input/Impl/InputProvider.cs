using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Services.Input.Impl
{
	public class InputProvider : IInitializable, PlayerInput.IPlayerActions, IDisposable, IInputProvider
	{
		private readonly PlayerInput _playerInput;
		private readonly ReactiveCommand _onFire = new ReactiveCommand();
		
		public Vector2 MoveValue { get; private set; }
		public Vector2 LookValue { get; private set; }
		public Vector2 MousePosition { get; private set; }
		public IReactiveCommand<Unit> OnFireCommand => _onFire;

		public InputProvider()
		{
			_playerInput = new PlayerInput();
			_playerInput.Player.SetCallbacks(this);
		}
		
		public void Initialize()
		{
			_playerInput.Enable();
		}
		
		public void OnMove(InputAction.CallbackContext context)
		{
			MoveValue = context.ReadValue<Vector2>();
		}
		
		public void OnLook(InputAction.CallbackContext context)
		{
			LookValue = context.ReadValue<Vector2>();
		}

		public void OnFire(InputAction.CallbackContext context)
		{
			if (context.performed)
				_onFire?.Execute();
		}
		
		public void OnMousePosition(InputAction.CallbackContext context)
		{
			MousePosition = context.ReadValue<Vector2>();
		}

		public void Dispose()
		{
			_playerInput?.Dispose();
			_onFire?.Dispose();
		}
	}
}