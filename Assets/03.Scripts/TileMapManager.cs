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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int pos = GetWorldToCell(mousePoint);

            Debug.Log(pos);
        }
    }

    public Vector3Int GetWorldToCell(Vector3 vec)
    {
        return grid.WorldToCell(vec);
    }
    public Vector3 GetCellToWorld(Vector3Int vec)
    {
        return grid.CellToWorld(vec);
    }

}
