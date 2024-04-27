#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Zangeki.Modifier {

    public class FrameVFXEM : MonoBehaviour {

        [Header("Bake Target")]
        public FrameVFXTM tm;
        public DefaultAsset folderAsset;

    }

}
#endif