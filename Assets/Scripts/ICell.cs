using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomTilemap;

public interface ICell
{
    void Refresh(Vector2Int position, ITilemap tilemap, GameObject gameObject);
}
