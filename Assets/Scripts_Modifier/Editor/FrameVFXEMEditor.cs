#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Zangeki.Modifier {
    [CustomEditor(typeof(FrameVFXEM))]
    public class FrameVFXEMEditor : Editor {
        SerializedProperty folderProperty;

        private void OnEnable() {
            folderProperty = serializedObject.FindProperty("folderAsset");
        }

        public override void OnInspectorGUI() {
            serializedObject.Update();

            FrameVFXEM script = (FrameVFXEM)target;
            script.tm = (FrameVFXTM)EditorGUILayout.ObjectField("Bake Target", script.tm, typeof(FrameVFXTM), true);

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(folderProperty, new GUIContent("Image Folder"));
            if (EditorGUI.EndChangeCheck()) {
                serializedObject.ApplyModifiedProperties(); 
            }

            if (GUILayout.Button("Load Images") && script.folderAsset != null) {
                string folderPath = AssetDatabase.GetAssetPath(script.folderAsset);
                if (AssetDatabase.IsValidFolder(folderPath)) {
                    LoadImages(folderPath, script);
                    EditorUtility.SetDirty(script.tm);
                    AssetDatabase.SaveAssets();
                }
            }

            serializedObject.ApplyModifiedProperties(); 
        }

        private void LoadImages(string path, FrameVFXEM em) {
            em.tm.tap_left_frame = LoadSpritesFromPath(path + "/Spr_VFX_Tap_Left");
            em.tm.tap_right_frame = LoadSpritesFromPath(path + "/Spr_VFX_Tap_Right");
            em.tm.clang_break1_frame = LoadSpritesFromPath(path + "/Spr_VFX_Clang_Break1");
            em.tm.clang_break2_frame = LoadSpritesFromPath(path + "/Spr_VFX_Clang_Break2");
            em.tm.clang_break3_frame = LoadSpritesFromPath(path + "/Spr_VFX_Clang_Break3");
            em.tm.swoosh_left_frame = LoadSpritesFromPath(path + "/Spr_VFX_Swoosh_Left");
            em.tm.swoosh_right_frame = LoadSpritesFromPath(path + "/Spr_VFX_Swoosh_Right");
            em.tm.swoosh_break1_frame = LoadSpritesFromPath(path + "/Spr_VFX_Swoosh_Break1");
            em.tm.swoosh_break2_frame = LoadSpritesFromPath(path + "/Spr_VFX_Swoosh_Break2");
            em.tm.swoosh_break3_frame = LoadSpritesFromPath(path + "/Spr_VFX_Swoosh_Break3");
            em.tm.slash_left_frame = LoadSpritesFromPath(path + "/Spr_VFX_Slash_Left");
            em.tm.slash_right_frame = LoadSpritesFromPath(path + "/Spr_VFX_Slash_Right");
            em.tm.blade1_frame = LoadSpritesFromPath(path + "/Spr_VFX_Blade1");
            em.tm.blade2_frame = LoadSpritesFromPath(path + "/Spr_VFX_Blade2");
            em.tm.blade3_frame = LoadSpritesFromPath(path + "/Spr_VFX_Blade3");
            em.tm.blood1_frame = LoadSpritesFromPath(path + "/Spr_VFX_Blood1");
        }

        private Sprite[] LoadSpritesFromPath(string path) {
            string[] files = System.IO.Directory.GetFiles(path, "*.png");
            Debug.Log("Loading " + files.Length + " sprites from: " + path);

            Sprite[] sprites = new Sprite[files.Length];

            for (int i = 0; i < files.Length; i++) {
                Debug.Log("Attempting to load Sprite from path: " + path);
                string fileName = System.IO.Path.GetFileNameWithoutExtension(files[i]);
                string filePath = path + "/" + fileName + ".png";

                sprites[i] = AssetDatabase.LoadAssetAtPath<Sprite>(filePath);
                if (sprites[i] == null) {
                    Debug.LogWarning("Failed to load Sprite at: " + filePath);
                    TextureImporter importer = AssetImporter.GetAtPath(filePath) as TextureImporter;
                    if (importer != null) {
                        Debug.Log("Texture Type: " + importer.textureType);
                    }
                }
            }

            return sprites;
        }
    }
}
#endif