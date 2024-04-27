using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Zangeki {

    public class MapEntity : MonoBehaviour {

        public int typeID;
        public Vector2Int mapSize;

        public bool isBlind;

        public WaveModel leftWaveModel;
        public WaveModel rightWaveModel;

        public Vector2 middlePos;
        public Vector2 leftBound;
        public Vector2 rightBound;

        public float groundHeight;

        [SerializeField] Transform ground;

        public float timer;

        public void Ctor() {
            timer = 0;
        }

        public void IncTimer(float dt) {
            timer += dt;
        }

        public void SetGroundPos(Vector2 pos) {
            ground.position = pos;
        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}