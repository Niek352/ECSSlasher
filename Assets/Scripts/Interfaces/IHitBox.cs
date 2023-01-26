using UnityEngine;

namespace Interfaces
{
	public interface IHitBox
	{
		void ApplyHit(ref RaycastHit hit, GameEntity bullet);
	}

	public interface IEntityHitBox : IHitBox
	{
		GameEntity GetEntity();
	}
}