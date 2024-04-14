using System;
using MortiseFrame.Swing;
using UnityEngine;

namespace Zangeki {

    [CreateAssetMenu(fileName = "SO_GameConfig", menuName = "Zangeki/GameConfig")]
    public class GameConfig : ScriptableObject {

        // Game
        [Header("Game Config")]
        public float gameResetEnterTime;

        // Role
        [Header("Role Config")]
        public int ownerRoleTypeID;
        public int originalMapTypeID;

        // Camera
        [Header("DeadZone Config")]
        public Vector2 cameraDeadZoneNormalizedSize;

        [Header("Shake Config")]
        public float cameraShakeFrequency_roleDamage;
        public float cameraShakeAmplitude_roleDamage;
        public float cameraShakeDuration_roleDamage;
        public EasingType cameraShakeEasingType_roleDamage;
        public EasingMode cameraShakeEasingMode_roleDamage;

    }

}