using UnityEngine;

namespace Zangeki {

    public static class GameRoleVFXDomain {

        public static void TickRoleWalkVFX(GameBusinessContext ctx, RoleEntity role, float dt) {
            if (role.allyStatus == AllyStatus.Player) {
                return;
            }

            role.walkVFXTimer += dt;
            if (role.walkVFXTimer < role.walkVFXInterval) {
                return;
            }
            role.walkVFXTimer = 0;
            var dir = role.faceDir;
            Debug.Log($"Role {role.typeID} Walk VFX {dir}");
            if (dir == Vector2.left) {
                GameVFXDomain.VFX_PlayTapLeft(ctx, role.Pos);
            } else if (dir == Vector2.right) {
                GameVFXDomain.VFX_PlayTapRight(ctx, role.Pos);
            }
        }

    }

}