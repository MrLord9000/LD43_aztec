using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

public class PlayAndExit : MonoBehaviour {

    private bool show = false;

    // Update is called once per frame
    void Update()
    {


        this.gameObject.SetActive(show);

    }
    private void OnMouseOver()
    {
        Debug.Log("a");
        show = true;
    }
    private void OnMouseExit()
    { 
        show = false;
    }

}