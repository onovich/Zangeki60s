using System;
using UnityEngine;

namespace Zangeki {

    [CreateAssetMenu(fileName = "SO_Role", menuName = "Zangeki/RoleTM")]
    public class RoleTM : ScriptableObject {

        public int typeID;
        public AllyStatus allyStatus;
        public AIType aiType;

        public float moveSpeed;
        public float jumpForce;
        public float g;
        public float fallingSpeedMax;

        public int hp;

        public Sprite mesh;
        public GameObject deadVFX;
        public float deadVFXDuration;
    }

}