using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject tileSpritePrefab;
    private GameObject tileSprite;

    [SerializeField]
    private Color hoverColor;

    [SerializeField]
    private Color activeColor;

    private bool isClicked = false;

    public Vector2 currentTileCoordinates = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        tileSprite = Instantiate(tileSpritePrefab, new Vector2(0, 0), Quaternion.identity);
        tileSprite.GetComponent<SpriteRenderer>().color = hoverColor;
    }

    // Update is called once per frame
    void Update()
    {
        currentTileCoordinates = TileSystem.GridBaseToCartesian(TileSystem.CartesianToTile(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        tileSprite.transform.position = currentTileCoordinates;
        if(Input.GetKeyDown(KeyCode.Mouse0) && !isClicked)
        {
            isClicked = true;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0) && isClicked)
        {
            isClicked = false;
        }

        if(isClicked)
        {
            tileSprite.GetComponent<SpriteRenderer>().color = activeColor;
        }
        else
        {
            tileSprite.GetComponent<SpriteRenderer>().color = hoverColor;
        }
    }
}
