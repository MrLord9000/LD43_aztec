using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicFakePerspective : MonoBehaviour {

    public float offset = .5f;

    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        spr.sortingOrder = -((int)((transform.position.y + offset) * 10));
    }
}
