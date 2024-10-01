using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] Tilemap mapTile;
    [SerializeField] Tilemap colorTile;

    [SerializeField] Tile redColorTile;
    [SerializeField] Tile greenColorTile;
    [SerializeField] Tile grayColorTile;

    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3Int GetWorldToCell(Vector3 vec)
    {
        return grid.WorldToCell(vec);
    }
    public Vector3 GetCellToWorld(Vector3Int vec)
    {
        return grid.CellToWorld(vec);
    }



    [SerializeField] List<Vector3Int> beforePossibleTilePos = new List<Vector3Int>();
    List<TileBase> beforePossibleTile = new List<TileBase>();


    /// <summary>
    /// Set Tile color Gray
    /// SkillArea
    /// </summary>
    /// <param name="originPos"></param>
    /// <param name="areas"></param>
    public void SetAreaColor(Vector3Int originPos, Vector3Int[] areas)
    {
        //Debug.Log(originPos);

        for (int i = 0; i < areas.Length; i++)
        {
            beforePossibleTilePos.Add(originPos + areas[i]);
            beforePossibleTile.Add(colorTile.GetTile(originPos + areas[i]));

            //Debug.Log(originPos + areas[i]);
            colorTile.SetTile(originPos + areas[i], grayColorTile);
        }
    }
    public void ReleaseAreaColor()
    {
        if (beforePossibleTilePos.Count == 0) return;

        for (int i = 0; i < beforePossibleTilePos.Count; i++)
        {
            colorTile.SetTile(beforePossibleTilePos[i], beforePossibleTile[i]);
        }

        beforePossibleTilePos = new List<Vector3Int>();
        beforePossibleTile = new List<TileBase>();
    }




    [SerializeField] List<Vector3Int> beforeTargetTilePos = new List<Vector3Int>();
    List<TileBase> beforeTargetTile = new List<TileBase>();

    public void SetRedColor(Vector3Int originPos, Vector3Int[] areas)
    {
        SwapBeforeTile();

        //Debug.Log(originPos);

        for (int i = 0; i < areas.Length; i++)
        {
            //Debug.Log(originPos + areas[i]);

            beforeTargetTilePos.Add(originPos + areas[i]);
            beforeTargetTile.Add(colorTile.GetTile(originPos + areas[i]));

            colorTile.SetTile(originPos + areas[i], redColorTile);
            
        }
    }
    public void SetRedColor(Vector3Int originPos, Vector3Int areas)
    {
        SwapBeforeTile();

        //Debug.Log(originPos);

        beforeTargetTilePos.Add(originPos + areas);
        beforeTargetTile.Add(colorTile.GetTile(originPos + areas));

        colorTile.SetTile(originPos + areas, redColorTile);

    }

    public void SwapBeforeTile()
    {
        if (beforeTargetTilePos.Count == 0) return;

        for (int i = 0; i < beforeTargetTilePos.Count; i++)
        {
            colorTile.SetTile(beforeTargetTilePos[i], beforeTargetTile[i]);
        }

        beforeTargetTilePos = new List<Vector3Int>();
        beforeTargetTile = new List<TileBase>();
    }
}
