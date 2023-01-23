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
		
		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterInstance(_viewData).As<IViewData>();
			builder.RegisterInstance(_playerData).As<IPlayerData>();
		}
	}
}