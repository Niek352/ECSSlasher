using UnityEngine;

namespace Enemy.Movement.Abstract
{
	public abstract class AbstractMovement : IMovement
	{
		public abstract bool ReachedTarget { get; }
		public abstract void Move(float deltaTime);
	}

	public interface IMovement
	{
		bool ReachedTarget { get; }
		void Move(float deltaTime);
	}
}