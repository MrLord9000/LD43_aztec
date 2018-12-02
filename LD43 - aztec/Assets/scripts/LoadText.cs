using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum What { units, workers, warriors, farmers };

public class LoadText : MonoBehaviour {

    public What thing;
    public Board b;
    private Text number;
    private void Start()
    {
        number = GetComponent<Text>();
    }
    private void Update()
    {
        switch(thing)
        {
            case What.units:
                number.text = b.nUnits.ToString();
                break;
            case What.farmers:
                number.text = b.nFarmers.ToString();
                break;
            case What.warriors:
                number.text = b.nWarriors.ToString();
                break;
            case What.workers:
                number.text = b.nWorkers.ToString();
                break;
        }
            
    }
}
