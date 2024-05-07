using MortiseFrame.Swing;
using UnityEngine;

namespace Zangeki {

    public static class GameRoleFSMController {

        public static void FixedTickFSM(GameBusinessContext ctx, RoleEntity role, float dt) {

            FixedTickFSM_Any(ctx, role, dt);

            RoleFSMStatus status = role.FSM_GetStatus();
            if (status == RoleFSMStatus.Idle) {
                FixedTickFSM_Idle(ctx, role, dt);
            } else if (status == RoleFSMStatus.Dead) {
                FixedTickFSM_Dead(ctx, role, dt);
            } else if (status == RoleFSMStatus.Casting) {
                FixedTickFSM_Casting(ctx, role, dt);
            } else if (status == RoleFSMStatus.Leaving) {
                FixedTickFSM_Leaving(ctx, role, dt);
            } else {
                GLog.LogError($"GameRoleFSMController.FixedTickFSM: unknown status: {status}");
            }

        }

        static void FixedTickFSM_Any(GameBusinessContext ctx, RoleEntity role, float dt) {

        }

        static void FixedTickFSM_Idle(GameBusinessContext ctx, RoleEntity role, float dt) {
            RoleFSMComponent fsm = role.FSM_GetComponent();
            if (fsm.idle_isEntering) {
                fsm.idle_isEntering = false;
            }

            // Move
            GameRoleDomain.ApplyMove(ctx, role, dt);

            // Cast
            if (role.allyStatus == AllyStatus.Player) {
                GameRoleDomain.ApplyCast(ctx, role);
            } else {
                GameRoleDomain.ApplyAutoCast(ctx, role);
            }

            // Stage
            GameRoleDomain.ApplyStage(ctx, role);

        }

        static void FixedTickFSM_Casting(GameBusinessContext ctx, RoleEntity role, float dt) {
            RoleFSMComponent fsm = role.FSM_GetComponent();
            if (fsm.casting_isEntering) {
                fsm.casting_isEntering = false;
            }

            if (fsm.casting_currentFrame == fsm.casting_swooshFrame) {
                if (role.allyStatus == AllyStatus.Enemy) {
                    GameRoleVFXDomain.RolePlaySwooshVFX(ctx, role);
                }
            }

            // Move
            GameRoleDomain.ApplyMove(ctx, role, dt);

            if (fsm.casting_currentFrame == fsm.casting_slashFrame) {
                if (role.allyStatus == AllyStatus.Enemy) {
                    GameRoleVFXDomain.RolePlaySlashVFX(ctx, role);
                }
            }

            // Damage
            if (fsm.casting_currentFrame == fsm.casting_damageFrame) {
                GameRoleDomain.ApplyDamage(ctx, role);
            }

            // Stage
            GameRoleDomain.ApplyStage(ctx, role);

            // Frame
            fsm.Casting_IncFrame();

            // CD
            if (role.allyStatus == AllyStatus.Enemy) {
                return;
            }
            if (fsm.casting_currentFrame >= fsm.casting_totalFrame) {
                fsm.EnterIdle();
            }
        }

        static void FixedTickFSM_Leaving(GameBusinessContext ctx, RoleEntity role, float dt) {
            RoleFSMComponent fsm = role.FSM_GetComponent();
            if (fsm.leaving_isEntering) {
                fsm.idle_isEntering = false;
            }

            // Move
            GameRoleDomain.ApplyMove(ctx, role, dt);

            // Stage
            GameRoleDomain.ApplyStage(ctx, role);

            // Leaving
            var startAlpha = 1.0f;
            var endAlpha = 0.0f;
            var duration = fsm.leaving_totalFrame;
            var current = fsm.leaving_currentFrame;
            if (current >= duration) {
                return;
            }
            var alpha = EasingHelper.Easing(startAlpha, endAlpha, current, duration, EasingType.Linear);
            role.Color_SetAlpha(alpha);
            fsm.Leaving_IncFrame();
        }

        static void FixedTickFSM_Dead(GameBusinessContext ctx, RoleEntity role, float dt) {
            RoleFSMComponent fsm = role.FSM_GetComponent();
            if (fsm.dead_isEntering) {
                fsm.dead_isEntering = false;
            }

            // VFX
            if (role.allyStatus == AllyStatus.Enemy) {
                GameRoleVFXDomain.RolePlaySwooshBreakVFX(ctx, role);
            } else {
                VFXParticelApp.AddVFXToWorld(ctx.vfxParticelContext, role.deadVFXName, role.deadVFXDuration, role.Pos);
            }

            // Camera
            GameCameraDomain.ShakeOnce(ctx);
            role.needTearDown = true;
        }

    }

}