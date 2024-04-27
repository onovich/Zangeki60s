using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Zangeki {

    [CreateAssetMenu(fileName = "TM_Map", menuName = "Zangeki/MapTM")]
    public class MapTM : ScriptableObject {

        public int typeID;
        public bool isBlind;

        public Vector2Int mapSize;
        public float groundHeight;

        // Wave
        public WaveTM leftWaveTM;
        public WaveTM rightWaveTM;

        // Point
        public Vector2 middlePoint;
        public Vector2 leftBound;
        public Vector2 rightBound;

        // Camera
        public Vector2 cameraConfinerWorldMax;
        public Vector2 cameraConfinerWorldMin;

    }

}