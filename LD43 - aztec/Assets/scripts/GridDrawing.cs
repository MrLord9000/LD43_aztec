using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDrawing : MonoBehaviour
{
    [SerializeField]
    private int gridExtent = 3;
    [SerializeField]
    private float bufferOffset = 1f;

    public GameObject testTile;

    public GameObject gridSprite;
    public GameObject spriteMask;
    public GameObject tileContainer;

    private Camera mainCamera;
    private Vector2 cameraDim;

    public void Awake()
    {
        mainCamera = Camera.main;
    }

    public void Start()
    {
        SpawnExtended(new Vector2(0, 0));
        TileLoopScreen(testTile);
    }

    public void Update()
    {
        //Debug.Log("Camera dimensions: x = " + mainCamera.orthographicSize * mainCamera.aspect + " y = " + mainCamera.orthographicSize);
        cameraDim.Set(mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize);
        TileLoopScreen(testTile);

        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        spriteMask.transform.position = mousePos;
    }

    private void TileLoopScreen(GameObject tile)
    {
        Vector2 tileCenter = tile.gameObject.transform.position;
        Vector2 tileDim = tile.GetComponent<SpriteRenderer>().sprite.rect.size;
        //Debug.Log("Tile center: " + tileCenter);
        //Debug.Log("Tile dimensions: " + tileDim);
        //Debug.Log("Camera center: " + mainCamera.transform.position);
        Debug.Log("Camera dimensions: " + cameraDim);
        // Checking the left to right screen bounds
        if (tileCenter.x + tileDim.x/2f < mainCamera.transform.position.x - (cameraDim.x + bufferOffset))
        {
            //Debug.Log("Should move the tile now.");
            //tile.transform.position.Set(tile.transform.position.x + tileDim.x * Mathf.Floor( (cameraDim.x * 2f)/ tileDim.x), tile.transform.position.y, 0);
            tile.transform.position = new Vector2(tile.transform.position.x + tileDim.x * Mathf.Floor((cameraDim.x * 2f) / tileDim.x), tile.transform.position.y);
        }

    }

    private void SpawnExtended(Vector2 origin)
    {
        origin = new Vector2(origin.x - gridExtent/2, origin.y - gridExtent/2);
        for(int i = 0; i < gridExtent; i++)
        {
            for(int j = 0; j < gridExtent; j++)
            {
                int i_temp = i;
                //if (j % 2 == 1) i_temp++;
                //if (i_temp % 2 == 0)
                //{
                    gridCellSpawn(origin.x + i, origin.y + j);
                //}
            }
        }
    }

    private void gridCellSpawn(float x, float y)
    {
        Vector2 cartesianOrigin = TileSystem.GridBaseToCartesian(new Vector2(x, y));
        GameObject.Instantiate(gridSprite, cartesianOrigin, new Quaternion(0, 0, 0, 0));
    }
}
