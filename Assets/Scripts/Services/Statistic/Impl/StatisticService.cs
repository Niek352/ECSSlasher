using System;
using UniRx;

namespace Services.Statistic.Impl
{
	public class StatisticService : IStatisticService, IDisposable
	{
		public ReactiveProperty<int> NumberKilledEnemies { get; set; } = new ReactiveProperty<int>();
		
		public void Dispose()
		{
			NumberKilledEnemies?.Dispose();
		}
	}
}