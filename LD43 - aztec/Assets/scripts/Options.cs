using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Options: MonoBehaviour
{

    public GameObject OptionsMenu;

    private bool sw = false;

    private void OnValidate()
    {
        OptionsMenu.SetActive(sw);
    }

    private void OnMouseDown()
    {
        sw = !sw;
        OptionsMenu.SetActive(sw);
        print("aaa");
    }
}
