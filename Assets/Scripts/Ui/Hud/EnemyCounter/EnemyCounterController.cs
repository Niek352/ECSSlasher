using System;
using Services.Statistic;
using UniRx;
using VContainer.Unity;
using VContainerUi.Abstraction;

namespace Ui.Hud.EnemyCounter
{
	public class EnemyCounterController : UiController<EnemyCounterView>, IStartable, IDisposable
	{
		private readonly IStatisticService _statisticService;
		private IDisposable _subscribe;

		public EnemyCounterController(IStatisticService statisticService)
		{
			_statisticService = statisticService;
		}

		public void Start()
		{
			_subscribe = _statisticService.NumberKilledEnemies.Subscribe(OnStatisticChanged);
		}
		
		private void OnStatisticChanged(int obj)
		{
			View.Counter.text = $"Killed Enemies : {obj.ToString()}";
		}
		
		public void Dispose()
		{
			_subscribe?.Dispose();
		}
	}
}