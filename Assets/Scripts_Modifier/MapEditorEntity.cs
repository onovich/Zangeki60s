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
        [SerializeField] WaveTM leftWaveTM;
        [SerializeField] WaveTM rightWaveTM;
        [SerializeField] Transform pointGroup;

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
            mapTM.leftWaveTM = leftWaveTM;
            mapTM.rightWaveTM = rightWaveTM;
        }

        void BakeSpawnPoint() {
            var editors = pointGroup.GetComponentsInChildren<SpawnPointEditorEntity>();
            if (editors == null) {
                Debug.Log("SpawnPointEditor Not Found");
            }
            for (int i = 0; i < editors.Length; i++) {
                var editor = editors[i];
                editor.Rename(i);
            }
            mapTM.leftBound = editors[0].GetPos();
            mapTM.middlePoint = editors[1].GetPos();
            mapTM.rightBound = editors[2].GetPos();
        }

        void OnDrawGizmos() {
            Gizmos.color = Color.green;
        }

    }

}