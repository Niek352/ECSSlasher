using System.Collections.Generic;
using Model.Enemy;
using UnityEngine;

namespace Db.EnemyData.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(EnemyData), fileName = nameof(EnemyData))]
	public class EnemyData : ScriptableObject, IEnemyData
	{
		[SerializeField] private List<EnemyModel> _enemyModels;

		public IReadOnlyList<EnemyModel> EnemyModels => _enemyModels;

		public EnemyModel GetEnemy(EnemyType enemyType)
		{
			foreach (var model in _enemyModels)
			{
				if (enemyType == model.EnemyType)
					return model;
			}
			return null;
		}
	}
}