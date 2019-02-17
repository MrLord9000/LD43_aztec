using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject tileSpritePrefab;
    private GameObject tileSprite;

    public Vector2 currentTileCoordinates = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        tileSprite = Instantiate(tileSpritePrefab, new Vector2(0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        currentTileCoordinates = TileSystem.GridBaseToCartesian(TileSystem.CartesianToTile(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        tileSprite.transform.position = currentTileCoordinates;
    }
}
