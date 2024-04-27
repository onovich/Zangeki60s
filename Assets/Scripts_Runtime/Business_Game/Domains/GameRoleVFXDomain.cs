using UnityEngine;

namespace Zangeki {

    public static class GameRoleVFXDomain {

        public static void TickRoleWalkVFX(GameBusinessContext ctx, RoleEntity role, float dt) {
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
            role.walkVFXTimer = 0;
            var dir = role.faceDir;
            if (dir == Vector2.right) {
                GameVFXDomain.VFX_PlayTapLeft(ctx, role.Pos);
            } else if (dir == Vector2.left) {
                GameVFXDomain.VFX_PlayTapRight(ctx, role.Pos);
            }
        }

        public static void RolePlayCastVFX(GameBusinessContext ctx, RoleEntity role) {

            if (role.allyStatus == AllyStatus.Player) {
                return;
            }

            if (role.fsmCom.status != RoleFSMStatus.Casting) {
                return;
            }

            var dir = role.faceDir;
            var pos = role.Pos + new Vector2(0, 0.5f);
            if (dir == Vector2.right) {
                GameVFXDomain.VFX_PlaySwooshRight(ctx, pos);
            } else if (dir == Vector2.left) {
                GameVFXDomain.VFX_PlaySwooshLeft(ctx, pos);
            }

        }

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
                GameVFXDomain.VFX_PlaySlashRight(ctx, pos);
            } else if (dir == Vector2.left) {
                GameVFXDomain.VFX_PlaySlashLeft(ctx, pos);
            }

        }

    }

}