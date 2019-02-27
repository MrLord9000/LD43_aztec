
#define UNITY_EDITOR 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PseudoButton : MonoBehaviour {

    public BuildingType type;
    private Building parent;
    //other buttons
    public GameObject button1;
    public GameObject button2;


    // Use this for initialization
    void Start () {
        parent = GetComponentInParent<Building>();
	}
	
	// Update is called once per frame
	void OnMouseDown() {
        parent.SetType(type);
        Destroy(button1);
        Destroy(button2);
        Destroy(this.gameObject);
        Destroy(parent.GetComponent<HouseButtons>());
        Destroy(this);
    }
}
