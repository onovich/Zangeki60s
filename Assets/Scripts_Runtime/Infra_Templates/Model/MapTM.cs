using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Zangeki {

    [CreateAssetMenu(fileName = "SO_Map", menuName = "Zangeki/MapTM")]
    public class MapTM : ScriptableObject {

        public int typeID;

        public Vector2Int mapSize;

        // Terrain
        public Vector2Int[] terrainSpawnPosArr;

        // Role Spawn 
        public Vector2 SpawnPoint;

        // Camera
        public Vector2 cameraConfinerWorldMax;
        public Vector2 cameraConfinerWorldMin;

    }

}