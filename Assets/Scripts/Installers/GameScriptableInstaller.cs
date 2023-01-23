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
		
		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterInstance(_viewData).As<IViewData>();
		}
	}
}