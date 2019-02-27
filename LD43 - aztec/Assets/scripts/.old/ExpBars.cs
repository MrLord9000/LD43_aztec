
#define UNITY_EDITOR 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ExpBars : MonoBehaviour {

    public Image builderBar;
    public Image farmerBar;
    public Image soldierBar;

    private Unit unit;

    private void Start()
    {
        unit = GetComponent<Unit>();
    }

    private void Update()
    {
        builderBar.fillAmount = (float)unit.builderLevel.exp / (float)unit.expRequire;
        farmerBar.fillAmount = (float)unit.farmerLevel.exp / (float)unit.expRequire;
        soldierBar.fillAmount = (float)unit.soldierLevel.exp / (float)unit.expRequire;
    }

}
