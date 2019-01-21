using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTile : MonoBehaviour
{
    public int tileX;
    public int tileZ;
    public TileMap map;

    private void OnMouseUp()
    {
       map.MoveSelcPawnTo(tileX, tileZ);
    }
}
