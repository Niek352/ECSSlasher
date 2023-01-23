using UniRx;
using UnityEngine;

namespace Services.Input
{
	public interface IInputProvider
	{
		Vector2 MoveValue { get; }
		Vector2 LookValue { get; }
		Vector2 MousePosition { get; }
		IReactiveCommand<Unit> OnFireCommand { get; }
	}
}