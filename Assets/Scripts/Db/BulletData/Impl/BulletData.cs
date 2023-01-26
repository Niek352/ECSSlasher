using UnityEngine;

namespace Db.BulletData.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(BulletData), fileName = nameof(BulletData))]
	public class BulletData : ScriptableObject, IBulletData
	{
	}
}