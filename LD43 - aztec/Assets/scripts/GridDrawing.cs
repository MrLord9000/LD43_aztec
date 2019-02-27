using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDrawing : MonoBehaviour
{
    [SerializeField]
    private int gridExtent = 3;

    public GameObject gridSprite;
    public GameObject spriteMask;

    private Camera mainCamera;

    public void Awake()
    {
        mainCamera = Camera.main;
    }

    public void Start()
    {
        spawnExtended(new Vector2(0, 0));
    }

    public void Update()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        spriteMask.transform.position = mousePos;
    }

    private void spawnExtended(Vector2 origin)
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
