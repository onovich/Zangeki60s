using System;
using UnityEngine;

namespace Zangeki {

    public class RoleEntity : MonoBehaviour {

        // Base Info
        public int entityID;
        public int typeID;
        public string typeName;
        public AllyStatus allyStatus;

        // Attr
        public float moveSpeed;
        public Vector2 Velocity => rb.velocity;
        public Vector2 faceDir;
        public float attackDistance;
        public int hpMax;
        public int hp;

        // Skill
        public int skillTotalFrame;
        public int swooshFrame;
        public int swooshBreakFrame;
        public int swooshBreakFrameEnd;
        public int slashFrame;
        public int damageFrame;

        // State
        public bool needTearDown;

        // Timer
        public float walkVFXInterval;
        public float walkVFXTimer;

        // FSM
        public RoleFSMComponent fsmCom;

        // Input
        public RoleInputComponent inputCom;

        // Render
        [SerializeField] public Transform body;
        RoleMod roleMod;
        public RoleMod RoleMod => roleMod;

        // VFX
        public string deadVFXName;
        public float deadVFXDuration;

        public RoleVFXComponent vfxCom;

        // Physics
        [SerializeField] Rigidbody2D rb;

        // Pos
        public Vector2 Pos => Pos_GetPos();

        public void Ctor() {
            fsmCom = new RoleFSMComponent();
            inputCom = new RoleInputComponent();
            vfxCom = new RoleVFXComponent();
        }

        // Pos
        public void Pos_SetPos(Vector2 pos) {
            transform.position = pos;
        }

        Vector2 Pos_GetPos() {
            return transform.position;
        }

        // Attr
        public float Attr_GetMoveSpeed() {
            return moveSpeed;
        }

        // Cast
        public void Cast_ApplyCast() {
            if (inputCom.skillAxis == Vector2.zero) {
                return;
            }
            Cast();
        }

        public void Cast() {
            roleMod?.PlayAttack();
            fsmCom.EnterCasting(skillTotalFrame, damageFrame, slashFrame, swooshFrame);
        }

        // Move
        public void Move_ApplyMove(float dt) {
            float dir = 0f;
            if (allyStatus == AllyStatus.Player) {
                dir = inputCom.skillAxis.x;
            } else if (allyStatus == AllyStatus.Enemy) {
                dir = faceDir.x;
                Move_Apply(dir, Attr_GetMoveSpeed(), dt);
            } else {
                GLog.LogError($"Move_ApplyMove: unknown allyStatus: {allyStatus}");
            }
            Move_SetFace(dir * Vector2.right);
        }

        public void Move_Stop() {
            Move_Apply(0, 0, 0);
        }

        void Move_Apply(float xAxis, float moveSpeed, float fixdt) {
            var velo = rb.velocity;
            velo.x = xAxis * moveSpeed;
            rb.velocity = velo;
        }

        public void Move_SetFace(Vector2 moveDir) {
            if (moveDir != Vector2.zero) {
                faceDir = moveDir;
            }

            if (moveDir.x != 0) {
                body.localScale = new Vector3(Mathf.Abs(body.localScale.x) * -Mathf.Sign(moveDir.x),
                                              body.localScale.y,
                                              body.localScale.z);
            }
        }

        // Color
        public void Color_SetAlpha(float alpha) {
            roleMod?.SetColorAlpha(alpha);
        }

        // FSM
        public RoleFSMStatus FSM_GetStatus() {
            return fsmCom.status;
        }

        public RoleFSMComponent FSM_GetComponent() {
            return fsmCom;
        }

        public void FSM_EnterIdle() {
            fsmCom.EnterIdle();
        }

        public void FSM_EnterDead() {
            fsmCom.EnterDead();
        }

        // Mod
        public void Mod_Set(RoleMod mod) {
            roleMod = mod;
        }

        // Frame
        public bool Frame_CanBreakSwoosh(int currentFrame) {
            var res = currentFrame >= swooshBreakFrame && currentFrame <= swooshBreakFrameEnd;
            if (!res) {
                GLog.Log($"Frame_CanBreakSwoosh: {currentFrame} not in range {swooshBreakFrame} - {swooshBreakFrameEnd}");

            }
            return res;
        }

        // VFX
        public void TearDown() {
            vfxCom.Clear();
            roleMod?.TearDown();
            Destroy(this.gameObject);
        }

    }

}