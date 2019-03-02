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
    public Transform tileContainer;
    //private GameObject[] allTiles;

    private Camera mainCamera;
    private Vector2 cameraDim;

    public void Awake()
    {
        mainCamera = Camera.main;
        cameraDim.Set(CameraHandler.GetMaxCameraSize() * mainCamera.aspect, CameraHandler.GetMaxCameraSize());
    }

    public void Start()
    {
        SpawnExtended();
        //TileLoopScreen(testTile.transform);
    }

    public void Update()
    {
        //Debug.Log("Camera dimensions: x = " + mainCamera.orthographicSize * mainCamera.aspect + " y = " + mainCamera.orthographicSize);
        //cameraDim.Set(mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize);

        //allTiles = tileContainer.GetComponentsInChildren<GameObject>();
        for (int i = 0; i < tileContainer.childCount; i++)
        {
            TileLoopScreen(tileContainer.GetChild(i));
        }
        //TileLoopScreen(testTile.transform);

        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        spriteMask.transform.position = mousePos;
    }

    private void TileLoopScreen(Transform tile)
    {
        Vector2 tilePivot = tile.position;
        Vector2 tileDim = tile.GetComponent<SpriteRenderer>().sprite.rect.size;

        // Checking the left to right screen bounds
        if (tilePivot.x + tileDim.x < mainCamera.transform.position.x - (cameraDim.x + bufferOffset))
        {
            tile.transform.position =   TileSystem.GridBaseToCartesian(
                                        TileSystem.CartesianToTile(new Vector2(tile.transform.position.x + tileDim.x * Mathf.Ceil( ((cameraDim.x * 2f) + bufferOffset) / tileDim.x ), tile.transform.position.y)));
        }
        else if (tilePivot.x > mainCamera.transform.position.x + (cameraDim.x + bufferOffset))
        {
            tile.transform.position =   TileSystem.GridBaseToCartesian(
                                        TileSystem.CartesianToTile(new Vector2(tile.transform.position.x - tileDim.x * Mathf.Ceil( ((cameraDim.x * 2f) + bufferOffset) / tileDim.x ), tile.transform.position.y)));
        }
        if (tilePivot.y + tileDim.y < mainCamera.transform.position.y - (cameraDim.y + bufferOffset))
        {
            tile.transform.position =   TileSystem.GridBaseToCartesian(
                                        TileSystem.CartesianToTile(new Vector2(tile.transform.position.x, tile.transform.position.y + tileDim.y * Mathf.Ceil(((cameraDim.y * 2f) + bufferOffset) / tileDim.y))));
        }
        else if (tilePivot.y - tileDim.y > mainCamera.transform.position.y + (cameraDim.y + bufferOffset))
        {
            tile.transform.position =   TileSystem.GridBaseToCartesian(
                                        TileSystem.CartesianToTile(new Vector2(tile.transform.position.x, tile.transform.position.y - tileDim.y * Mathf.Ceil(((cameraDim.y * 2f) + bufferOffset) / tileDim.y))));
        }
    }

    private void SpawnExtended()
    {
        Vector2 leftTopBounds = TileSystem.CartesianToTile(new Vector2(mainCamera.transform.position.x - (cameraDim.x + bufferOffset), mainCamera.transform.position.y + (cameraDim.y + bufferOffset)));
        //float leftTileBounds = leftTopBounds.x;
        //Debug.Log("Left top bounds: " + leftTopBounds);
        //Debug.Log("X: " + (mainCamera.transform.position.x - (cameraDim.x + bufferOffset)) );
        //Debug.Log("Y: " + (mainCamera.transform.position.y + (cameraDim.y + bufferOffset)) );
        //Vector2 rightTopBounds = TileSystem.CartesianToTile(new Vector2(mainCamera.transform.position.x + (cameraDim.x + bufferOffset), mainCamera.transform.position.y + (cameraDim.y + bufferOffset)));
        //Vector2 leftBottomBounds = TileSystem.CartesianToTile(new Vector2(mainCamera.transform.position.x - (cameraDim.x + bufferOffset), mainCamera.transform.position.y - (cameraDim.y + bufferOffset)));
        //Vector2 rightBottomBounds = TileSystem.CartesianToTile(new Vector2(mainCamera.transform.position.x + (cameraDim.x + bufferOffset), mainCamera.transform.position.y - (cameraDim.y + bufferOffset)));

        Vector2 tileDim = gridSprite.GetComponent<SpriteRenderer>().sprite.rect.size;

        //for (int i = 0; i < Mathf.Ceil( (cameraDim.y * 2f)/tileDim.y ); i++)
        //{
        //    for(int j = 0; j < Mathf.Ceil( (cameraDim.x * 2f)/tileDim.x ); j++)
        //    {
        //        //Vector2 cartesianOrigin = TileSystem.GridBaseToCartesian(TileSystem.CartesianToTile(new Vector2(leftTopBounds.x * (j + 1), leftTopBounds.y * (i + 1))));
        //        //GameObject.Instantiate(gridSprite, cartesianOrigin, new Quaternion(0, 0, 0, 0), tileContainer);
        //        gridCellSpawn(leftTopBounds.x + j, leftTopBounds.y - i);
        //    }
        //}

        Vector2 origin = new Vector2( -(gridExtent / 2), -(gridExtent / 2) );
        for (int i = 0; i < gridExtent; i++)
        {
            for (int j = 0; j < gridExtent; j++)
            {
                gridCellSpawn(origin.x + i, origin.y + j);
            }
        }

        Transform[] childTransforms = tileContainer.GetComponentsInChildren<Transform>();
        for (int i = 0; i < childTransforms.Length; i++)
        {
            if ( ((childTransforms[i].position.x < mainCamera.transform.position.x - (cameraDim.x + bufferOffset) || childTransforms[i].position.x > mainCamera.transform.position.x + (cameraDim.x + bufferOffset)) ||
                  (childTransforms[i].position.y < mainCamera.transform.position.y - (cameraDim.y + bufferOffset) || childTransforms[i].position.y > mainCamera.transform.position.y + (cameraDim.y + bufferOffset))))
            {
                Destroy(childTransforms[i].gameObject);
            }
        }
    }

    private void gridCellSpawn(float x, float y)
    {
        //Debug.Log("Spawning a tile!");
        Vector2 cartesianOrigin = TileSystem.GridBaseToCartesian(new Vector2(x, y));
        GameObject.Instantiate(gridSprite, cartesianOrigin, new Quaternion(0, 0, 0, 0), tileContainer);
    }
}
