using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TmpResourcesUI : MonoBehaviour
{
    [SerializeField]
    private GridData gridData;

    // Update is called once per frame
    void Update()
    {
        GetComponentsInChildren<Text>()[0].text = "Food: " + gridData.globalFoodAmount.ToString();
        GetComponentsInChildren<Text>()[1].text = "*multiplier: " + gridData.globalFoodIncomeMultiplier.ToString();
    }
}
