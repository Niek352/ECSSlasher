using UnityEngine;

namespace Db.PlayerData.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(PlayerData), fileName = nameof(PlayerData))]
	public class PlayerData : ScriptableObject, IPlayerData
	{
		[SerializeField] private float _moveSpeed;
		[SerializeField] private float _rotationSpeed;

		public float MoveSpeed => _moveSpeed;
		public float RotationSpeed => _rotationSpeed;
	}
}