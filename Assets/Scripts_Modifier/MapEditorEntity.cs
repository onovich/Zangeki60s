using System;
using System.Collections.Generic;
using TriInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Zangeki.Modifier {

    public class MapEditorEntity : MonoBehaviour {

        [SerializeField] int typeID;
        [SerializeField] GameObject mapSize;
        [SerializeField] MapTM mapTM;
        [SerializeField] Tilemap tilemap_terrain;
        [SerializeField] TileBase tilebase_terrain;
        [SerializeField] Transform spawnPointGroup;
        [SerializeField] Vector2 cameraConfinerWorldMax;
        [SerializeField] Vector2 cameraConfinerWorldMin;

        IndexService indexService;

        [Button("Bake")]
        void Bake() {
            indexService = new IndexService();
            indexService.ResetIndex();
            BakeTerrain();
            BakeMapInfo();
            BakeSpawnPoint();

            EditorUtility.SetDirty(mapTM);
            AssetDatabase.SaveAssets();
            Debug.Log("Bake Sucess");
        }

        void BakeMapInfo() {
            mapTM.typeID = typeID;
            mapTM.tileBase_terrain = tilebase_terrain;
            mapTM.mapSize = mapSize.transform.localScale.RoundToVector2Int();
        }

        void BakeTerrain() {
            var terrainSpawnPosList = new List<Vector2Int>();
            for (int x = tilemap_terrain.cellBounds.x; x < tilemap_terrain.cellBounds.xMax; x++) {
                for (int y = tilemap_terrain.cellBounds.y; y < tilemap_terrain.cellBounds.yMax; y++) {
                    var pos = new Vector3Int(x, y, 0);
                    var tile = tilemap_terrain.GetTile(pos);
                    if (tile == null) continue;
                    terrainSpawnPosList.Add(pos.ToVector2Int());
                }
            }
            mapTM.terrainSpawnPosArr = terrainSpawnPosList.ToArray();
        }

        void BakeSpawnPoint() {
            var editor = spawnPointGroup.GetComponent<SpawnPointEditorEntity>();
            if (editor == null) {
                Debug.Log("SpawnPointEditor Not Found");
            }
            editor.Rename();
            var posInt = editor.GetPosInt();
            mapTM.SpawnPoint = posInt;
        }

        void OnDrawGizmos() {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube((cameraConfinerWorldMax + cameraConfinerWorldMin) / 2, cameraConfinerWorldMax - cameraConfinerWorldMin);
        }

    }

}