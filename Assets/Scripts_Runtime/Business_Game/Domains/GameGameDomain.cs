using MortiseFrame.Swing;
using TenonKit.Prism;
using UnityEngine;

namespace Zangeki {

    public static class GameGameDomain {

        public static void NewGame(GameBusinessContext ctx) {

            var config = ctx.templateInfraContext.Config_Get();

            // Game
            var game = ctx.gameEntity;
            game.fsmComponent.Gaming_Enter();

            // Map
            var mapTypeID = config.originalMapTypeID;
            var map = GameMapDomain.Spawn(ctx, mapTypeID);
            var has = ctx.templateInfraContext.Map_TryGet(mapTypeID, out var mapTM);
            if (!has) {
                GLog.LogError($"MapTM Not Found {mapTypeID}");
            }

            // Role
            var player = ctx.playerEntity;

            // - Owner
            var spawnPoint = mapTM.middlePoint;
            var owner = GameRoleDomain.Spawn(ctx,
                                             config.ownerRoleTypeID,
                                             spawnPoint);
            player.ownerRoleEntityID = owner.entityID;
            ctx.ownerSpawnPoint = spawnPoint;

            // Camera
            CameraApp.Init(ctx.cameraContext, owner.transform, Vector2.zero, mapTM.cameraConfinerWorldMax, mapTM.cameraConfinerWorldMin);

            // UI

            // Cursor

        }

        public static void ApplyRestartGame(GameBusinessContext ctx) {

            var spawnPoint = ctx.ownerSpawnPoint;
            var game = ctx.gameEntity;
            var enterTime = game.fsmComponent.gameOver_enterTime;
            var gameOver_isEntering = game.fsmComponent.gameOver_isEntering;

            if (gameOver_isEntering) {
                game.fsmComponent.gameOver_isEntering = false;
                CameraApp.SetMoveToTarget(ctx.cameraContext, spawnPoint, enterTime, EasingType.Linear, EasingMode.None, onComplete: () => {
                    ExitGame(ctx);
                    NewGame(ctx);
                    game.fsmComponent.Gaming_Enter();
                });
            }

        }

        public static void ApplyGameResult(GameBusinessContext ctx) {
            var owner = ctx.Role_GetOwner();
            var game = ctx.gameEntity;
            var config = ctx.templateInfraContext.Config_Get();
            if (owner == null || owner.needTearDown) {
                game.fsmComponent.GameOver_Enter(config.gameResetEnterTime);
            }
        }

        public static void ExitGame(GameBusinessContext ctx) {
            // Game
            var game = ctx.gameEntity;
            game.fsmComponent.NotInGame_Enter();

            // Map
            GameMapDomain.UnSpawn(ctx);

            // Role
            int roleLen = ctx.roleRepo.TakeAll(out var roleArr);
            for (int i = 0; i < roleLen; i++) {
                var role = roleArr[i];
                GameRoleDomain.UnSpawn(ctx, role);
            }

            // UI
        }

    }
}