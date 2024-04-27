using System;
using UnityEngine;

namespace Zangeki {

    [CreateAssetMenu(fileName = "TM_Wave", menuName = "Zangeki/WaveTM")]
    public class WaveTM : ScriptableObject {

        public int typeID;
        public float[] spawnTimeArr;
        public int[] roleTypeIDArr;

    }

}