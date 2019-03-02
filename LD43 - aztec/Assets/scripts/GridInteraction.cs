using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInteraction : MonoBehaviour
{
    public GridData gridData;

    public void Start()
    {
        RemoveTileOccupation(new Vector2(0, 0));
    }

    public bool CheckTileOccupation(Vector2 tilePos)
    {
        if (gridData.gridBuildings[tilePos] == null) return false;
        else return true;
    }

    public void SetTileOccupation(Vector2 tilePos, GameObject building)
    {
        gridData.gridBuildings[tilePos] = building;
    }

    public void RemoveTileOccupation(Vector2 tilePos)
    {
        try
        {
            gridData.gridBuildings.RemoveEntry(tilePos);
        }
        catch (ElementNotFound e)
        {
            Debug.Log("Element " + e.Message + " not found in collection.");
        }
    }
}
