using UnityEngine;
using CustomTilemap;

public class TerrainGenerator : MonoBehaviour
{
    public int Height, Width;
    public GroundTile Tile;
    [SerializeField] private bool _isGenerateOnStart = false;

    public void Start()
    {
        if (_isGenerateOnStart)
        {
            GenerateAndRender();
        }
    }

    public void GenerateAndRender()
    {
        var tileMap = Generate();
        GetComponent<TilemapRender>().Render(tileMap);
        GetComponent<PolygonCollider2D>().points = tileMap.GetClosedMesh();
    }

    private ITilemap Generate()
    {
        int groundHeight = 5;
        HeightmapBasedTilemap tilemap = new HeightmapBasedTilemap(Width, Tile);
        for(int x = 0; x < Width; x++)
        {
            if (x % 2 == 0) groundHeight += Random.Range(-1, 2);
            tilemap.SetHeight(x, groundHeight);    
        }

        return tilemap;
    }
}

//namespace CustomTilemap
//{
    //public interface ICell
    //{
    //    void Refresh(Vector2Int position, ITilemap tilemap, GameObject gameObject);
    //}

    //public interface ITilemap
    //{
    //    int Count { get; }
    //    int Height { get; }
    //    int Width { get; }
    //    ICell GetCell(Vector2Int position);
    //}

    //[CreateAssetMenu(menuName = "GroundTile")]
    //public class GroundTile : ScriptableObject, ICell
    //{
    //    public void Refresh(Vector2Int position, ITilemap tilemap, GameObject gameObject)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //public class HeightmapBasedTilemap : ITilemap
    //{
    //    public int Count
    //    {
    //        get
    //        {
    //            return _heights.Sum();
    //        }
    //    }

    //    public int Height
    //    {
    //        get
    //        {
    //            return _heights.Max();
    //        }
    //    }

    //    public int Width
    //    {
    //        get
    //        {
    //            return _heights.Length;
    //        }
    //    }

    //    private int[] _heights;
    //    private ICell _cell;

    //    public HeightmapBasedTilemap(int width, ICell cell)
    //    {
    //        _heights = new int[width];
    //        _cell = cell;
    //    }

    //    public void SetHeight(int x, int value)
    //    {
    //        if (x > 0 && x < _heights.Length) throw new System.ArgumentOutOfRangeException("x");

    //        _heights[x] = value;
    //    }

    //    public ICell GetCell(Vector2Int position)
    //    {
    //        if (position.x > 0 && position.x < _heights.Length) throw new System.ArgumentOutOfRangeException("x");

    //        if(position.y > _heights[position.x])
    //        {
    //            return null;
    //        }
    //        else
    //        {
    //            return _cell;
    //        }
    //    }

    //}

//}
