using UniRx;

namespace Services.Statistic
{
	public interface IStatisticService
	{
		ReactiveProperty<int> NumberKilledEnemies { get; set; }
	}
}