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

    }

}