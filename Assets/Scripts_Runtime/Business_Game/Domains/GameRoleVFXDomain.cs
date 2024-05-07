using MortiseFrame.Swing;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace Zangeki {

    public static class GameRoleVFXDomain {

        // Walk
        public static void TickRoleTapVFX(GameBusinessContext ctx, RoleEntity role, float dt) {
            if (role.allyStatus == AllyStatus.Player) {
                return;
            }

            if (role.fsmCom.status != RoleFSMStatus.Idle) {
                return;
            }

            role.walkVFXTimer += dt;
            if (role.walkVFXTimer < role.walkVFXInterval) {
                return;
            }
            role.walkVFXTimer -= role.walkVFXInterval;
            var dir = role.faceDir;
            if (dir == Vector2.right) {
                VFXFrameApp.VFX_PlayTapLeft(ctx, role.Pos);
            } else if (dir == Vector2.left) {
                VFXFrameApp.VFX_PlayTapRight(ctx, role.Pos);
            }
        }

        // Casting
        public static void RolePlaySwooshVFX(GameBusinessContext ctx, RoleEntity role) {

            if (role.allyStatus == AllyStatus.Player) {
                return;
            }

            if (role.fsmCom.status != RoleFSMStatus.Casting) {
                return;
            }

            var dir = role.faceDir;
            var pos = role.Pos + new Vector2(0, 0.5f);
            var vfxID = -1;
            if (dir == Vector2.right) {
                vfxID = VFXFrameApp.VFX_PlaySwooshRight(ctx, pos);
            } else if (dir == Vector2.left) {
                vfxID = VFXFrameApp.VFX_PlaySwooshLeft(ctx, pos);
            }
            if (vfxID == 1) {
                return;
            }
            role.vfxCom.AddVFX(vfxID);

        }

        // Casting Break
        public static void RolePlaySwooshBreakVFX(GameBusinessContext ctx, RoleEntity role) {

            if (role.allyStatus == AllyStatus.Player) {
                return;
            }

            if (role.fsmCom.status != RoleFSMStatus.Dead) {
                return;
            }

            role.vfxCom.ForEach(vfxID => {
                VFXFrameApp.StopVFXManualy(ctx.vfxFrameContext, vfxID);
            });

            var dir = role.faceDir;
            var pos = role.Pos + new Vector2(0, 0.5f);
            VFXFrameApp.VFX_PlaySwooshBreak1(ctx, pos);
        }

        // Attck
        public static void RolePlaySlashVFX(GameBusinessContext ctx, RoleEntity role) {

            if (role.allyStatus == AllyStatus.Player) {
                return;
            }

            if (role.fsmCom.status != RoleFSMStatus.Casting) {
                return;
            }

            var dir = role.faceDir;
            var pos = role.Pos;
            if (dir == Vector2.right) {
                VFXFrameApp.VFX_PlaySlashRight(ctx, pos);
            } else if (dir == Vector2.left) {
                VFXFrameApp.VFX_PlaySlashLeft(ctx, pos);
            }

        }

        // Blood
        public static void RolePlayBloodVFX(GameBusinessContext ctx, RoleEntity role) {

            if (role.allyStatus == AllyStatus.Player) {
                return;
            }

            if (role.fsmCom.status != RoleFSMStatus.Dead) {
                return;
            }

            var pos = role.Pos;
            var rdOffsetX = Random.Range(-0.1f, 0.1f);
            var rdOffsetY = Random.Range(-0.1f, 0.1f);
            pos += new Vector2(rdOffsetX, rdOffsetY);
            var rdTime = Random.Range(1f, 2.5f);
            var rdFadingOutTime = Random.Range(0.1f, 0.5f);
            bool flix = role.faceDir.x > 0;

            var id = VFXFrameApp.VFX_PlayBlood(ctx, pos);
            VFXFrameApp.SetDelayEndSec(ctx.vfxFrameContext, id, rdTime);

            VFXFrameApp.SetFadingOut(ctx.vfxFrameContext, id, rdFadingOutTime, EasingType.Sine, EasingMode.EaseOut);
            VFXFrameApp.FlipX(ctx.vfxFrameContext, id, flix);
        }

    }

}