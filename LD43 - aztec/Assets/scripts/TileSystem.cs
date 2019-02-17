using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSystem : MonoBehaviour
{

    // Grid Base: [63,-20] , [45,31]
    public static Vector2 GridBaseToCartesian(Vector2 GridBaseCoordinates)
    {
        Vector2 CartesianCoordinates;
        CartesianCoordinates.x = 63.0f * GridBaseCoordinates.x + 45.0f * GridBaseCoordinates.y;
        CartesianCoordinates.y = -20.0f * GridBaseCoordinates.x + 31.0f * GridBaseCoordinates.y;
        return CartesianCoordinates;
    }
    public static Vector2 CartesianToGridBase(Vector2 CartesianCoordinates)
    {
        Vector2 GridBaseCoordinates;
        GridBaseCoordinates.x = (31.0f * CartesianCoordinates.x) / 2853.0f - (5.0f * CartesianCoordinates.y) / 317.0f;
        GridBaseCoordinates.y = (20.0f * CartesianCoordinates.x) / 2853.0f + (7.0f * CartesianCoordinates.y) / 317.0f;
        return GridBaseCoordinates;
    }
    public static Vector2 GridBaseToTile(Vector2 GridBaseCoordinates)
    {
        Vector2 Tile;
        Tile.x = Mathf.Floor(GridBaseCoordinates.x);
        Tile.y = Mathf.Floor(GridBaseCoordinates.y);
        return Tile;
    }
    public static Vector2 CartesianToTile(Vector2 CartesianCoordinates)
    {
        Vector2 GridBaseCoordinates = CartesianToGridBase(CartesianCoordinates);
        return GridBaseToTile(GridBaseCoordinates);
    }

    

 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static Vector2 OldGridBaseToCartesian(Vector2 GridBaseCoordinates)
    {
        Vector2 CartesianCoordinates;
        CartesianCoordinates.x = 63.0f * GridBaseCoordinates.x + 45.0f * GridBaseCoordinates.y;
        CartesianCoordinates.y = 20.0f * GridBaseCoordinates.x - 31.0f * GridBaseCoordinates.y;
        return CartesianCoordinates;
    }
    public static Vector2 OldCartesianToGridBase(Vector2 CartesianCoordinates)
    {
        Vector2 GridBaseCoordinates;
        GridBaseCoordinates.x = (31.0f * CartesianCoordinates.x) / 2853.0f + (5.0f * CartesianCoordinates.y) / 317.0f;
        GridBaseCoordinates.y = (20.0f * CartesianCoordinates.x) / 2853.0f - (7.0f * CartesianCoordinates.y) / 317.0f;
        return GridBaseCoordinates;
    }
}
