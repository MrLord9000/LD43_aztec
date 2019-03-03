using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Globals;

public class TmpResourcesUI : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponentsInChildren<Text>()[0].text = "Food: " + GameManager.gridData.globalFoodAmount.ToString();
        GetComponentsInChildren<Text>()[1].text = "*multiplier: " + GameManager.gridData.globalFoodIncomeMultiplier.ToString();
    }
}
