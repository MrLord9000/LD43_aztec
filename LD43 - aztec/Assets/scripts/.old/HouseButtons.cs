using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseButtons : MonoBehaviour {

    public GameObject workshopButton;
    public GameObject farmButton;
    public GameObject fortButton;

    private bool buttonsVisible = false;
    // Use this for initialization
    void Start () {
        workshopButton.SetActive(buttonsVisible);
        farmButton.SetActive(buttonsVisible);
        fortButton.SetActive(buttonsVisible);
    }
	
	// Update is called once per frame
	void OnMouseDown() {
        buttonsVisible = !buttonsVisible;

        workshopButton.SetActive(buttonsVisible);
        farmButton.SetActive(buttonsVisible);
        fortButton.SetActive(buttonsVisible);
    }
}
