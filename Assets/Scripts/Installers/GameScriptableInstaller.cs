using Db.BulletData;
using Db.BulletData.Impl;
using Db.EnemyData;
using Db.EnemyData.Impl;
using Db.PlayerData;
using Db.PlayerData.Impl;
using Db.ViewData;
using Db.ViewData.Impl;
using UnityEngine;
using VContainer;
using VContainer.Extensions;

namespace Installers
{
	[CreateAssetMenu(menuName = "Settings/Installer/" + nameof(GameScriptableInstaller), fileName = nameof(GameScriptableInstaller))]
	public class GameScriptableInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private ViewData _viewData;
		[SerializeField] private PlayerData _playerData;
		[SerializeField] private BulletData _bulletData;
		[SerializeField] private EnemyData _enemyData;
		
		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterInstance(_viewData).As<IViewData>();
			builder.RegisterInstance(_playerData).As<IPlayerData>();
			builder.RegisterInstance(_bulletData).As<IBulletData>();
			builder.RegisterInstance(_enemyData).As<IEnemyData>();
		}
	}
}