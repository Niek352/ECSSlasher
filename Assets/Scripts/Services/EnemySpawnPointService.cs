using System;
using Services.CameraProvider;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Services
{
	public interface IEnemySpawnPointService
	{
		Vector3 GetEnemySpawnPoint();
	}
	
	public class EnemySpawnPointService : IEnemySpawnPointService
	{
		private readonly ICameraProvider _cameraProvider;
		private const float ENEMY_SIZE = 2f;
	
		public EnemySpawnPointService(ICameraProvider cameraProvider)
		{
			_cameraProvider = cameraProvider;
		}

		public Vector3 GetEnemySpawnPoint()
		{
			var side = (Side)Random.Range(0, Enum.GetValues(typeof(Side)).Length);
			var point = CenterBySide(side) + RandomizePoint(side);
			return point;
		}

		private Vector3 RandomizePoint(Side side)
		{
			return side switch
			{
				Side.Left => new Vector3(0, 0, Random.Range(-CamUtils.GetHighestPoint(_cameraProvider.Camera), CamUtils.GetHighestPoint(_cameraProvider.Camera))),
				Side.Right => new Vector3(0, 0, Random.Range(-CamUtils.GetHighestPoint(_cameraProvider.Camera), CamUtils.GetHighestPoint(_cameraProvider.Camera))),
				Side.Up => new Vector3(Random.Range(-CamUtils.GetWidthestPoint(_cameraProvider.Camera), CamUtils.GetWidthestPoint(_cameraProvider.Camera)), 0),
				Side.Down => new Vector3(Random.Range(-CamUtils.GetWidthestPoint(_cameraProvider.Camera), CamUtils.GetWidthestPoint(_cameraProvider.Camera)), 0),
				_ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
			};
		}
		private Vector3 CenterBySide(Side side)
		{
			return side switch
			{
				Side.Left => new Vector3(-CamUtils.GetWidthestPoint(_cameraProvider.Camera) - ENEMY_SIZE, 0),
				Side.Right => new Vector3(CamUtils.GetWidthestPoint(_cameraProvider.Camera) + ENEMY_SIZE, 0),
				Side.Up => new Vector3(0,0, CamUtils.GetHighestPoint(_cameraProvider.Camera) + ENEMY_SIZE),
				Side.Down => new Vector3(0, 0,-CamUtils.GetHighestPoint(_cameraProvider.Camera) - ENEMY_SIZE),
				_ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
			};
		}
	
	
		private enum Side : byte
		{
			Left,
			Right,
			Up,
			Down
		}
	}
}