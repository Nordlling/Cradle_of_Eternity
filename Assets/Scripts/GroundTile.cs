using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomTilemap;

[CreateAssetMenu(menuName = "GroundTile")]
public class GroundTile : ScriptableObject, ICell
{
    public Sprite Default;
    public void Refresh(Vector2Int position, ITilemap tilemap, GameObject gameObject)
    {
        SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
        render.sprite = Default;
    }

    public bool Exist(Vector2Int position, ITilemap tilemap)
    {
        if (position.x < 0 || position.x >= tilemap.Width) return false;

        var tile = tilemap.GetCell(position);

        return tile != null;
    }
}
