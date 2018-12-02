using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public Board b;
    public What what;

    Button progressBar;
  
	void Start ()
    {
        progressBar = GetComponent<Button>();
	}
	

	void Update ()
    {
        switch(what)
        {
            case What.farmers:
                progressBar.image.fillAmount = 1 - b.unitSpawnTimeLeft / b.unitSpawnTimeCost;
                break;
            case What.workers:
                progressBar.image.fillAmount = 1 - b.buildingTimeLeft / b.buildingTimeCost;
                break;
        }
        
    }
}
