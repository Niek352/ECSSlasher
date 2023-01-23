using UnityEngine;

namespace Db.BulletData
{
	public interface IBulletData
	{
		LayerMask BulletCollidedMask { get; }
	}
}