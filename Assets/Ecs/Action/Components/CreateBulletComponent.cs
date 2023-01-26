using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Components
{
	[Action]
	public class CreateBulletComponent : IComponent
	{
		public CreateBulletData CreateBulletData;
	}

	public readonly struct CreateBulletData
	{
		public readonly Vector3 SpawnPoint;
		public readonly Vector3 Velocity;
		public readonly float Damage;
		public readonly LayerMask LayerMask;
		public CreateBulletData(Vector3 spawnPoint, Vector3 velocity, float damage, LayerMask layerMask)
		{
			SpawnPoint = spawnPoint;
			Velocity = velocity;
			Damage = damage;
			LayerMask = layerMask;
		}
	}
}