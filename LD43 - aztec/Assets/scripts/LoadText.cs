using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum What { units, workers, warriors, farmers };

public class LoadText : MonoBehaviour {

    public What thing;
    private UnitStatistics stats;
    private Text number;
    private void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        stats = gameController.GetComponent<UnitStatistics>();
        number = GetComponent<Text>();
    }
    private void Update()
    {
        switch(thing)
        {
            case What.units:
                number.text = stats.NumberOf_Adults.ToString();
                break;
            case What.farmers:
                number.text = (stats.NumberOf_Builders + stats.NumberOf_Builders1 + stats.NumberOf_Builders2 + stats.NumberOf_Builders3).ToString();
                break;
            case What.warriors:
                number.text = (stats.NumberOf_Soldiers + stats.NumberOf_Soldiers1 + stats.NumberOf_Soldiers2 + stats.NumberOf_Soldiers3).ToString();
                break;
            case What.workers:
                number.text = (stats.NumberOf_Farmers + stats.NumberOf_Farmers1 + stats.NumberOf_Farmers2 + stats.NumberOf_Farmers3).ToString();
                break;
        }
            
    }
}
