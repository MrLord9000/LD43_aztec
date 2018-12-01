using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {

    public GameObject buttonBox;

    public bool sw = false;

    private void OnValidate()
    {
        buttonBox.SetActive(sw);
    }

    private void OnMouseDown()
    {
        sw = !sw;
        buttonBox.SetActive(sw);
    }
}
