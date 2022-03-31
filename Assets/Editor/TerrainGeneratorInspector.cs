using UnityEngine;
using UnityEditor;
using CustomTilemap;

[CustomEditor(typeof(TerrainGenerator))]
public class TerrainGeneratorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        TerrainGenerator target = (TerrainGenerator)base.target;
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate"))
        {
            target.GenerateAndRender();
        }
        if (GUILayout.Button("Clear"))
        {
            target.GetComponent<TilemapRender>().Clear();
        }
    }
}
