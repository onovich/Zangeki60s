using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Zangeki {

    [CreateAssetMenu(fileName = "TM_FrameVFX", menuName = "Zangeki/FrameVFXTM")]
    public class FrameVFXTM : ScriptableObject {

        [Header("Tap_Left")]
        public Sprite[] tap_left_frame;
        public Sprite[] tap_right_frame;

        [Header("Clang_Break")]
        public Sprite[] clang_break1_frame;
        public Sprite[] clang_break2_frame;
        public Sprite[] clang_break3_frame;

        [Header("Swoosh")]
        public Sprite[] swoosh_left_frame;
        public Sprite[] swoosh_right_frame;

        [Header("Swoosh_Break")]
        public Sprite[] swoosh_break1_frame;
        public Sprite[] swoosh_break2_frame;
        public Sprite[] swoosh_break3_frame;

        [Header("Slash")]
        public Sprite[] slash_left_frame;
        public Sprite[] slash_right_frame;

        [Header("Blade")]
        public Sprite[] blade1_frame;
        public Sprite[] blade2_frame;
        public Sprite[] blade3_frame;

        [Header("Blood")]
        public Sprite[] blood1_frame;

    }

}