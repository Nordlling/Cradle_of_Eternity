using UnityEngine;
using System.Linq;

namespace CustomTilemap
{

    public class TilemapRender : MonoBehaviour
    {
        public void Render(ITilemap tilemap)
        {
            Clear();

            for (int x = 0; x < tilemap.Width; x++)
            {
                for (int y = 0; y <= tilemap.Height; y++)
                {
                    var cell = tilemap.GetCell(new Vector2Int(x, y));
                    if(cell != null)
                    {
                        GameObject cellGo = CreateEmpty(new Vector2Int(x, y));
                        cell.Refresh(new Vector2Int(x, y), tilemap, cellGo);
                    }
                }
            }
        }

        public void Clear()
        {
            foreach (Transform child in transform.OfType<Transform>().ToList())
            {
#if UNITY_EDITOR
                DestroyImmediate(child.gameObject);
#else
                Destroy(child.gameObject);
#endif
            }
        }

        public GameObject CreateEmpty(Vector2Int position)
        {
            GameObject result = new GameObject(position.ToString());
            var transform = result.GetComponent<Transform>();
            transform.parent = GetComponent<Transform>();
            transform.localPosition = new Vector3(position.x, position.y, 0);
            result.AddComponent<SpriteRenderer>();

            return result;
        }
    }

}
