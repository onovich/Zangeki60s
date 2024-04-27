using System;
using UnityEngine;

namespace Zangeki {

    [CreateAssetMenu(fileName = "TM_Role", menuName = "Zangeki/RoleTM")]
    public class RoleTM : ScriptableObject {

        [Header("Role Info")]
        public int typeID;
        public string typeName;
        public AllyStatus allyStatus;

        [Header("Role Attributes")]
        public float moveSpeed;
        public float attackDistance;
        public int skillTotalFrame;
        public int slashFrame;
        public int damageFrame;
        public int leavingTotalFrame;
        public int hpMax;
        public RoleMod mod;
        public GameObject deadVFX;
        public float deadVFXDuration;

        public float walkVFXInterval;
        
    }

}