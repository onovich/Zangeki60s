using MortiseFrame.Swing;
using UnityEngine;

namespace Zangeki {

    public static class GameRoleFSMController {

        public static void FixedTickFSM(GameBusinessContext ctx, RoleEntity role, float fixdt) {

            FixedTickFSM_Any(ctx, role, fixdt);

            RoleFSMStatus status = role.FSM_GetStatus();
            if (status == RoleFSMStatus.Idle) {
                FixedTickFSM_Idle(ctx, role, fixdt);
            } else if (status == RoleFSMStatus.Dead) {
                FixedTickFSM_Dead(ctx, role, fixdt);
            } else if (status == RoleFSMStatus.Casting) {
                FixedTickFSM_Casting(ctx, role, fixdt);
            } else if (status == RoleFSMStatus.Leaving) {
                FixedTickFSM_Leaving(ctx, role, fixdt);
            } else {
                GLog.LogError($"GameRoleFSMController.FixedTickFSM: unknown status: {status}");
            }

        }

        static void FixedTickFSM_Any(GameBusinessContext ctx, RoleEntity role, float fixdt) {

        }

        static void FixedTickFSM_Idle(GameBusinessContext ctx, RoleEntity role, float fixdt) {
            RoleFSMComponent fsm = role.FSM_GetComponent();
            if (fsm.idle_isEntering) {
                fsm.idle_isEntering = false;
            }

            // Move
            GameRoleDomain.ApplyMove(ctx, role, fixdt);

            // Cast
            if (role.allyStatus == AllyStatus.Friend) {
                GameRoleDomain.ApplyCast(ctx, role);
            } else {
                GameRoleDomain.ApplyAutoCast(ctx, role);
            }

            // Stage
            GameRoleDomain.ApplyStage(ctx, role);

        }

        static void FixedTickFSM_Casting(GameBusinessContext ctx, RoleEntity role, float fixdt) {
            RoleFSMComponent fsm = role.FSM_GetComponent();
            if (fsm.casting_isEntering) {
                fsm.casting_isEntering = false;
            }

            // Move
            GameRoleDomain.ApplyMove(ctx, role, fixdt);

            // Stage
            GameRoleDomain.ApplyStage(ctx, role);

            // CD
            if (role.allyStatus == AllyStatus.Enemy) {
                return;
            }
            fsm.Casting_IncTimer(fixdt);
            if (fsm.casting_currentTimer >= fsm.casting_duration) {
                fsm.EnterIdle();
            }
        }

        static void FixedTickFSM_Leaving(GameBusinessContext ctx, RoleEntity role, float fixdt) {
            RoleFSMComponent fsm = role.FSM_GetComponent();
            if (fsm.leaving_isEntering) {
                fsm.idle_isEntering = false;
            }

            // Move
            GameRoleDomain.ApplyMove(ctx, role, fixdt);

            // Stage
            GameRoleDomain.ApplyStage(ctx, role);

            // Leaving
            var startAlpha = 1.0f;
            var endAlpha = 0.0f;
            var duration = fsm.leaving_duration;
            var current = fsm.leaving_currentTimer;
            if (current >= duration) {
                return;
            }
            var alpha = EasingHelper.Easing(startAlpha, endAlpha, current, duration, EasingType.Linear);
            role.Color_SetAlpha(alpha);
            fsm.Leaving_IncTimer(fixdt);
        }

        static void FixedTickFSM_Dead(GameBusinessContext ctx, RoleEntity role, float fixdt) {
            RoleFSMComponent fsm = role.FSM_GetComponent();
            if (fsm.dead_isEntering) {
                fsm.dead_isEntering = false;
            }

            // VFX
            VFXApp.AddVFXToWorld(ctx.vfxContext, role.deadVFXName, role.deadVFXDuration, role.Pos);

            // Camera
            CameraApp.ShakeOnce(ctx.cameraContext, ctx.cameraContext.mainCameraID);
            role.needTearDown = true;
        }

    }

}