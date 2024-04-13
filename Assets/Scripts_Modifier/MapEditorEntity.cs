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
        [SerializeField] Transform spawnPointGroup;

        IndexService indexService;

        [Button("Bake")]
        void Bake() {
            indexService = new IndexService();
            indexService.ResetIndex();
            BakeMapInfo();
            BakeSpawnPoint();

            EditorUtility.SetDirty(mapTM);
            AssetDatabase.SaveAssets();
            Debug.Log("Bake Sucess");
        }

        void BakeMapInfo() {
            mapTM.typeID = typeID;
            mapTM.mapSize = mapSize.transform.localScale.RoundToVector2Int();
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
        }

    }

}