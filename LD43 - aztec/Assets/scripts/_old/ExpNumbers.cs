using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpNumbers : MonoBehaviour {

    public Text builderText;
    public Text farmerText;
    public Text soldierText;

    private Unit unit;

    private void Start()
    {
        unit = GetComponent<Unit>();
    }

    private void Update()
    {
        builderText.text = unit.builderLevel.level.ToString();
        farmerText.text = unit.farmerLevel.level.ToString();
        soldierText.text = unit.soldierLevel.level.ToString();
    }

}
