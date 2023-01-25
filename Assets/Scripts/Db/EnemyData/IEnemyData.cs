using System.Collections.Generic;
using Model.Enemy;

namespace Db.EnemyData
{
	public interface IEnemyData
	{
		IReadOnlyList<EnemyModel> EnemyModels { get; }
		EnemyModel GetEnemy(EnemyType enemyType);
	}
}