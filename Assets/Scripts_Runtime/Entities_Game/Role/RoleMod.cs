using System;
using UnityEngine;

namespace Zangeki {

    public class RoleMod : MonoBehaviour {

        [SerializeField] SpriteRenderer spr;
        [SerializeField] Animator anim;

        public void SetSprite(Sprite sprite) {
            spr.sprite = sprite;
        }

        public void PlayIdle() {
            anim.Play("idle");
        }

        public void PlayAttack() {
            anim.Play("attack");
        }

        public void PlayAttackFail() {
            anim.Play("attack_fail");
        }

        public void PlayHurt() {
            anim.Play("hurt");
        }

        public void Anim_SetMovement(float speed) {
            anim.SetFloat("HorizontalMovement", speed);
        }

        public void TearDown() {
            Destroy(this.gameObject);
        }

    }

}