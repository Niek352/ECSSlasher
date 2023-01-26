using Model.Player;
using UnityEngine;

namespace Db.PlayerData.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(PlayerData), fileName = nameof(PlayerData))]
	public class PlayerData : ScriptableObject, IPlayerData
	{
		[SerializeField] private PlayerModel _playerModel;

		public PlayerModel PlayerModel => _playerModel;
	}
}