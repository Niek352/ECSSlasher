using UnityEngine;

namespace Ecs.Game.Extensions
{
    public static class GameExtensions
    {
        public static void CreatePlayer(
            this GameContext gameContext,
            Vector3 spawnPosition)
        {
            var gamePlayer = gameContext.CreateEntity();
            gamePlayer.IsPlayer = true;
            gamePlayer.AddPrefab("Player");
            gamePlayer.AddVelocity(Vector3.zero);
            gamePlayer.AddPosition(spawnPosition);
            gamePlayer.AddRotation(Quaternion.identity);
            gamePlayer.AddLookDirection(Vector3.forward);
            gamePlayer.IsInstantiate = true;
        }
        
        public static void CreateBullet(this GameContext gameContext,
            Vector3 spawnPosition,
            Vector3 velocity)
        {
            var gamePlayer = gameContext.CreateEntity();
            gamePlayer.IsBullet = true;
            gamePlayer.AddPrefab("Bullet");
            gamePlayer.AddVelocity(velocity);
            gamePlayer.AddLifeTime(5);
            gamePlayer.AddPosition(spawnPosition);
            gamePlayer.AddRotation(Quaternion.identity);
            gamePlayer.AddLookDirection(Vector3.forward);
            gamePlayer.IsInstantiate = true;
        }
        
        public static GameEntity CreateCamera(this GameContext game)
        {
            var entity = game.CreateEntity();
            entity.AddPrefab("Camera");
            entity.AddPosition(Vector3.zero);
            entity.AddRotation(Quaternion.identity);
            entity.IsCamera = true;
            entity.IsInstantiate = true;
            return entity;
        }
        
        public static GameEntity CreateVirtualCamera(this GameContext game)
        {
            var entity = game.CreateEntity();
            entity.AddPrefab("VirtualCamera");
            entity.AddPosition(Vector3.zero);
            entity.AddRotation(Quaternion.identity);
            entity.IsInstantiate = true;
            return entity;
        }

    }
}