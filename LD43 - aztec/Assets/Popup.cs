using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {

    public GameObject buttonBox;

    private void OnValidate()
    {
        buttonBox.SetActive(false);
    }

    private void OnMouseDown()
    {
        if(buttonBox.active)
            buttonBox.SetActive(false);
        else
            buttonBox.SetActive(true);

    }
}
