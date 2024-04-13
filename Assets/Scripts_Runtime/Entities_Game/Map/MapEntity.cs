using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Zangeki {

    public class MapEntity : MonoBehaviour {

        public int typeID;
        public Vector2Int mapSize;

        [SerializeField] Transform ground;

        public void Ctor() { }

        public void SetGroundPos(Vector2 pos) {
            ground.position = pos;
        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}