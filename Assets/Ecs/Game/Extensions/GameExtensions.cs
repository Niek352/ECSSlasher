using Ecs.Action.Components;
using Model;
using Model.Enemy;
using Model.Player;
using UnityEngine;

namespace Ecs.Game.Extensions
{
    public static class GameExtensions
    {
        public static void CreatePlayer(this GameContext gameContext,
            PlayerModel playerModel,
            Vector3 spawnPosition)
        {
            var entity = gameContext.CreateEntity();
            
            entity.IsPlayer = true;
            entity.AddMoveSpeed(playerModel.MoveSpeed);
            entity.AddHealth(playerModel.Health);
            entity.AddDefence(playerModel.Defence);
            entity.AddDamage(playerModel.Damage);
            entity.AddLayerMask(playerModel.BulletLayerMask);
            
            entity.AddPrefab("Player");
            entity.AddVelocity(Vector3.zero);
            entity.AddPosition(spawnPosition);
            entity.AddRotation(Quaternion.identity);
            entity.AddLookDirection(Vector3.forward);
            entity.IsInstantiate = true;
        }
        
        public static void CreateBullet(this GameContext gameContext,
            ref CreateBulletData bullet)
        {
            var gamePlayer = gameContext.CreateEntity();
            gamePlayer.IsBullet = true;
            gamePlayer.AddPrefab("Bullet");
            gamePlayer.AddVelocity(bullet.Velocity);
            gamePlayer.AddLayerMask(bullet.LayerMask);
            gamePlayer.AddLifeTime(5);
            gamePlayer.AddPosition(bullet.SpawnPoint);
            gamePlayer.AddDamage(bullet.Damage);
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

        public static GameEntity CreateEnemy(this GameContext game,
            EnemyModel enemyModel, 
            Vector3 position
            )
        {
            var entity = game.CreateEntity();
            entity.IsEnemy = true;
            entity.AddPrefab("Enemy");
            entity.AddEnemyModel(enemyModel);
            entity.AddPosition(position);
            entity.AddRotation(Quaternion.identity);
            
            entity.AddMoveSpeed(enemyModel.MoveSpeed);
            entity.AddLayerMask(enemyModel.BulletLayerMask);
            entity.AddHealth(enemyModel.Health);
            entity.AddDefence(enemyModel.Defence);
            entity.AddDamage(enemyModel.Damage);
            entity.AddCurrentAttackCooldown(0);
            entity.AddMaxAttackCooldown(enemyModel.AttackCooldown);
            entity.AddAttackRange(enemyModel.AttackRange);
            
            entity.IsInstantiate = true;
            return entity;
        }
    }
}