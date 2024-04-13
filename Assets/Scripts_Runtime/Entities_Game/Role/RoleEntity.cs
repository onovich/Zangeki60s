using System;
using UnityEngine;

namespace Zangeki {

    public class RoleEntity : MonoBehaviour {

        // Base Info
        public int entityID;
        public int typeID;
        public AllyStatus allyStatus;
        public AIType aiType;

        // Attr
        public float moveSpeed;
        public Vector2 Velocity => rb.velocity;
        public Vector2 faceDir;

        // State
        public bool needTearDown;

        // FSM
        public RoleFSMComponent fsmCom;

        // Input
        public RoleInputComponent inputCom;

        // Render
        [SerializeField] public Transform body;
        RoleMod roleMod;

        // VFX
        public string deadVFXName;
        public float deadVFXDuration;

        // Physics
        [SerializeField] Rigidbody2D rb;

        // Pos
        public Vector2 Pos => Pos_GetPos();

        public void Ctor() {
            fsmCom = new RoleFSMComponent();
            inputCom = new RoleInputComponent();
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
            if (!inputCom.isCasting) {
                return;
            }
            roleMod.PlayAttack();
        }

        // Move
        public void Move_ApplyMove(float dt) {
            Move_Apply(inputCom.moveAxis.x, Attr_GetMoveSpeed(), dt);
            Move_SetFace(inputCom.moveAxis);
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

        // Anim
        public void Anim_PlayIdle() {
            roleMod.PlayIdle();
        }

        public void Anim_PlayAttack() {
            roleMod.PlayAttack();
        }

        public void Anim_PlayAttackFail() {
            roleMod.PlayAttackFail();
        }

        public void Anim_PlayHurt() {
            roleMod.PlayHurt();
        }

        public void Anim_SetMovement(float speed) {
            roleMod.Anim_SetMovement(speed);
        }

        // VFX
        public void TearDown() {
            roleMod.TearDown();
            Destroy(this.gameObject);
        }

    }

}