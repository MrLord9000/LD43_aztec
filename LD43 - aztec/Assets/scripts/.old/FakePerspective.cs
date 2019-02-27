using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePerspective : MonoBehaviour {

    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sortingOrder = -((int)(transform.position.y * 10));
    }

}
