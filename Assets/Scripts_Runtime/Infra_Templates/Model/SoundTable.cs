using UnityEngine;

namespace Zangeki    {

    [CreateAssetMenu(fileName = "SoundTable", menuName = "Oshi/SoundTable")]
    public class SoundTable : ScriptableObject {

        [Header("Role SE")]
        public AudioClip roleMove;
        public float roleMoveVolume;

        public AudioClip roleDie;
        public float roleDieVolume;

        public AudioClip roleHurt;
        public float roleHurtVolume;

        public AudioClip roleSwoosh;
        public float roleSwooshVolume;

        public AudioClip roleSlash;
        public float roleSlashVolume;

        public AudioClip roleClang;
        public float roleClangVolume;

        public AudioClip roleSwooshBreak;
        public float roleSwooshBreakVolume;

        public AudioClip roleSlashBreak;
        public float roleSlashBreakVolume;

        [Header("BGM")]
        public AudioClip bgmLoop;
        public float bgmVolume;

    }

}