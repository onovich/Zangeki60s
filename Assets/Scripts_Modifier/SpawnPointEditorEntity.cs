using UnityEngine;

namespace Zangeki.Modifier {

    public class SpawnPointEditorEntity : MonoBehaviour {

        public void Rename(int index) {
            string side = "";
            if (index == 0) {
                side = "Left";
            } else if (index == 1) {
                side = "Middle";
            } else if (index == 2) {
                side = "Right";
            }
            this.gameObject.name = $"Spawn Point {side}";
        }

        public Vector2Int GetPosInt() {
            var posInt = this.transform.position.RoundToVector2Int();
            this.transform.position = posInt.ToVector3Int();
            return posInt;
        }

        public Vector2Int GetSizeInt() {
            var size = transform.localScale;
            var sizeInt = size.RoundToVector2Int();
            return sizeInt;
        }

    }

}