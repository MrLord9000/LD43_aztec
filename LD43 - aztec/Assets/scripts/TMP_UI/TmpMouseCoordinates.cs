using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TmpMouseCoordinates : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 CartesianCoordinates = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GetComponentsInChildren<Text>()[0].text = "Cartesian: " + CartesianCoordinates.ToString();
        GetComponentsInChildren<Text>()[1].text = "Grid Base: " + TileSystem.CartesianToGridBase(CartesianCoordinates).ToString();
        GetComponentsInChildren<Text>()[2].text = "Tile: " + TileSystem.CartesianToTile(CartesianCoordinates).ToString();

    }
}
