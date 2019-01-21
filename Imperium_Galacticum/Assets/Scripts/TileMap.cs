using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MapDataBase
{    
    public TileType[] tileTypes;
    private PathFinding pathFinding;

    int[,] tiles;    

    private void Awake()
    {
        GenerateMapData();        
        GenerateMapVisuals();

        pathFinding = gameObject.GetComponent<PathFinding>();
    }

    private void GenerateMapData()
    {
        tiles = new int[mapSizeX, mapSizeZ];

        // Main Space Tiles
        LoopTiles(0, mapSizeX, 0, mapSizeZ, 2);

        // Base P1
        LoopTiles(0, 3, 3, mapSizeZ - 4, 0);

        // Base P2
        LoopTiles(mapSizeX - 3, mapSizeX, 3, mapSizeZ - 4, 1);

        // Empty Space
        LoopTiles(mapSizeX / 2, mapSizeX / 2 + 1, 1, mapSizeZ - 10, 3);

        // Astroid Field Space
        LoopTiles(mapSizeX / 2 - 2, mapSizeX / 2 + 3, mapSizeZ - 10, mapSizeZ, 5);
    }

    private void LoopTiles(int xStart, int xEnd, int zStart, int zEnd, int tileType)
    {
        for (int x = xStart; x < xEnd; x++)
        {
            for (int z = zStart; z < zEnd; z++)
            {
                tiles[x, z] = tileType;
            }
        }
    }    

    void GenerateMapVisuals()
    {
        GameObject tileHolder = new GameObject("tileHolder");

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int z = 0; z < mapSizeZ; z++)
            {
                TileType tt = tileTypes[tiles[x, z]];
                GameObject newTile = Instantiate(tt.tileVisPrefab, new Vector3(x, 0, z), Quaternion.identity);
                newTile.transform.parent = tileHolder.transform;

                ClickTile ct = newTile.GetComponent<ClickTile>();
                ct.tileX = x;
                ct.tileZ = z;
                ct.map = this;
            }
        }
    }

    public Vector3 TileCoordToWorldCoord(int x, int z)
    {
        return new Vector3(x, 0.2f, z);
    }








    // Just connecting ClickTile to Pathfnding. -TODO: Cut out the middle man...
    public void MoveSelcPawnTo(int x, int z)
    {
        pathFinding.MoveSelcPawnTo1(x, z);
    }
}
