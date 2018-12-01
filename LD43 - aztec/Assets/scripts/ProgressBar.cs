using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public GameObject gameManager;
    private _SceneManager manager;

    Button progressBar;
  
	void Start ()
    {
        manager = gameManager.GetComponent<_SceneManager>();
        progressBar = GetComponent<Button>();
	}
	

	void Update ()
    {
        progressBar.image.fillAmount = 1 - manager.buildingTimeLeft / manager.buildingTimeCost;
    }
}
