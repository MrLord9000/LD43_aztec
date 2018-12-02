using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public Board b;

    private void Start()
    {
        b.lockedTiles.Add(new Vector2(transform.position.x, transform.position.y));
    }
}
