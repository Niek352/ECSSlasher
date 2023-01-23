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
    }
}