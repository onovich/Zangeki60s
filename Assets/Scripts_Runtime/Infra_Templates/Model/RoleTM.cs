using System;
using UnityEngine;

namespace Zangeki {

    [CreateAssetMenu(fileName = "SO_Role", menuName = "Zangeki/RoleTM")]
    public class RoleTM : ScriptableObject {

        public int typeID;
        public AllyStatus allyStatus;
        public AIType aiType;
        public float moveSpeed;
        public int direction;
        public RoleMod mod;
        public GameObject deadVFX;
        public float deadVFXDuration;
    }

}