using System;
using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary1.Enums;
using Db.BulletData;
using Interfaces;
using JCMG.EntitasRedux;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Pool;

namespace Ecs.Game.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 15, "Bullet")]
	public class BulletRayCastSystem : IUpdateSystem, IDisposable
	{
		private readonly IBulletData _bulletData;
		private readonly List<RaycastCommand> _tempList = new List<RaycastCommand>();
		private readonly IGroup<GameEntity> _bulletGroup;

		private JobHandle _jobHandle;
		private NativeArray<RaycastHit> _raycastHit = new NativeArray<RaycastHit>(0, Allocator.Persistent);
		private NativeArray<RaycastCommand> _raycastCommands = new NativeArray<RaycastCommand>(0, Allocator.Persistent);
		
		public BulletRayCastSystem(
			GameContext game,
			IBulletData bulletData)
		{
			_bulletData = bulletData;
			_bulletGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Bullet));
		}
		
		public void Update()
		{
			_tempList.Clear();
			_jobHandle.Complete();
			var bulletList = ListPool<GameEntity>.Get();
			_bulletGroup.GetEntities(bulletList);
			
			for (int i = 0; i < bulletList.Count; i++)
			{
				var b = bulletList[i];
				
				if (b.LifeTime.Value < 0)
				{
					b.Destroy();
					continue;
				}
				
				if (_raycastHit.Length > i)
				{
					var hit = _raycastHit[i];
				
					if (hit.collider != null)
					{
						if (hit.collider.TryGetComponent(out IHitBox box))
						{
							box.ApplyHit(ref hit, b);
						}
					
						b.Velocity.Value = Vector3.Reflect(b.Velocity.Value, hit.normal);
						b.Position.Value = hit.point;
						continue;
					}
				}
				
				var lastPosition = b.Position.Value;
				b.LifeTime.Value -= Time.deltaTime;
				var newPosition = CalculateNewPosition(b);
				b.ReplacePosition(newPosition);
				RaycastSegment(lastPosition, newPosition, _tempList);
			}
			
			if (_raycastCommands.IsCreated)
				_raycastCommands.Dispose();
			
			if (_raycastHit.IsCreated)
				_raycastHit.Dispose();
			
			_raycastCommands = new NativeArray<RaycastCommand>(_tempList.Count, Allocator.TempJob);
			for (int i = 0; i < _tempList.Count; i++)
				_raycastCommands[i] = _tempList[i];
			
			_raycastHit = new NativeArray<RaycastHit>(_tempList.Count, Allocator.TempJob);
			
			_jobHandle = RaycastCommand.ScheduleBatch(_raycastCommands, _raycastHit, 1);
			
			ListPool<GameEntity>.Release(bulletList);
		}
		
		private void RaycastSegment(Vector3 start, Vector3 end, List<RaycastCommand> tempList)
		{
			var direction = end - start;
			var distance = (end - start).magnitude;
			tempList.Add(new RaycastCommand(start, direction, distance, _bulletData.BulletCollidedMask));
		}
		
		private Vector3 CalculateNewPosition(GameEntity bullet)
		{
			return bullet.Position.Value + bullet.Velocity.Value * Time.deltaTime;
		}

		public void Dispose()
		{
			if (_raycastCommands.IsCreated)
				_raycastCommands.Dispose();
			
			if (_raycastHit.IsCreated)
				_raycastHit.Dispose();
		}
	}
}