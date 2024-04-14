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
                                             spawnPoint,
                                             Vector2.right);
            player.ownerRoleEntityID = owner.entityID;
            ctx.ownerSpawnPoint = spawnPoint;

            // Camera
            CameraApp.Init(ctx.cameraContext, owner.transform, Vector2.zero, mapTM.cameraConfinerWorldMax, mapTM.cameraConfinerWorldMin);

            // UI

            // Cursor

        }

        public static void ApplyGameOver(GameBusinessContext ctx, float dt) {
            var game = ctx.gameEntity;
            var fsm = game.fsmComponent;

            fsm.GameOver_DecTimer(dt);

            var enterTime = fsm.gameOver_enterTime;
            if (enterTime <= 0) {
                UIApp.GameOver_Open(ctx.uiContext);
            }
        }

        public static void RestartGame(GameBusinessContext ctx) {
            var game = ctx.gameEntity;
            var fsm = game.fsmComponent;
            ExitGame(ctx);
            NewGame(ctx);
            fsm.Gaming_Enter();
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
            UIApp.GameOver_Close(ctx.uiContext);
            
        }

    }
}