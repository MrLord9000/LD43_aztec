using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {

    public GameObject buttonBox;

    private bool sw = false;

    private void Start()
    {
        buttonBox.SetActive(sw);
    }

    private void OnMouseDown()
    {
        sw = !sw;
        buttonBox.SetActive(sw);
    }
}
