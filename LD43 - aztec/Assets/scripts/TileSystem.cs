using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSystem : MonoBehaviour
{
    // Grid Base: [63,-20] , [45,31]
    // Tile number = Grid Base coordinates   
    public static Vector2 GridBaseToCartesian(Vector2 GridBaseCoordinates)
    /* Translation from grid base coordinates to cartesian coordinates
     * used in CartesianToTile()
     */
    {
        Vector2 CartesianCoordinates;
        CartesianCoordinates.x = 63.0f * GridBaseCoordinates.x + 45.0f * GridBaseCoordinates.y;
        CartesianCoordinates.y = -20.0f * GridBaseCoordinates.x + 31.0f * GridBaseCoordinates.y;
        return CartesianCoordinates;
    }
    public static Vector2 CartesianToGridBase(Vector2 CartesianCoordinates)
    /* Translation from grid base coordinates to cartesian coordinates 
     * example of use:  get unity coordinates (X,Y) of tile number (A,B) 
     */
    {
        Vector2 GridBaseCoordinates;
        GridBaseCoordinates.x = (31.0f * CartesianCoordinates.x) / 2853.0f - (5.0f * CartesianCoordinates.y) / 317.0f;
        GridBaseCoordinates.y = (20.0f * CartesianCoordinates.x) / 2853.0f + (7.0f * CartesianCoordinates.y) / 317.0f;
        return GridBaseCoordinates;
    }
    public static Vector2 GridBaseToTile(Vector2 GridBaseCoordinates)
    /* Return number of tile wich contains specyfic point (input in Grid Base)
     * example of use: - snapping object to grid
     *                 - getting number of tile
     */
    {
        Vector2 Tile;
        Tile.x = Mathf.Floor(GridBaseCoordinates.x);
        Tile.y = Mathf.Floor(GridBaseCoordinates.y);
        return Tile;
    }
    public static Vector2 CartesianToTile(Vector2 CartesianCoordinates)
    /* Return number of tile wich contains specyfic point (input in Cartesian Base)
     * example of use: same as in GridBaseToTile()
     */
    {
        Vector2 GridBaseCoordinates = CartesianToGridBase(CartesianCoordinates);
        return GridBaseToTile(GridBaseCoordinates);
    }
    public static Vector2 GridBaseTileCenter(Vector2 GridBaseCoordinates, int Width = 1, int Higth = 1)
    /* Return cartesian coordinates of centre of tiles set (input in Grid Base)
     */
    {
        Vector2 Center = GridBaseToTile(GridBaseCoordinates);
        Center.x += Width / 2;
        Center.y += Higth / 2;
        return Center;
    }
    public static Vector2 CartesianToTileCenter(Vector2 CartesianCoordinates, int Width = 1, int Higth = 1)
    /* Return cartesian coordinates of centre of tiles set (input in Cartesian Base)
     */
    {
        Vector2 Center = CartesianToTile(CartesianCoordinates);
        Center.x += Width / 2;
        Center.y += Higth / 2;
        return Center;
    }
}
