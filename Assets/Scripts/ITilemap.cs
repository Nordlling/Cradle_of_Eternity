using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomTilemap;

public interface ITilemap
{
    int Count { get; }
    int Height { get; }
    int Width { get; }
    ICell GetCell(Vector2Int position);
    Vector2[] GetClosedMesh();
}
