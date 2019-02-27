using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInterface : MonoBehaviour {

    public Button builderButton;
    public Button farmerButton;
    public Button warriorButton;

    private Unit unitScr;

    private void Start()
    {
        unitScr = GetComponent<Unit>();
        builderButton.onClick.AddListener(BuilderAssign);
        warriorButton.onClick.AddListener(WarriorAssign);
        farmerButton.onClick.AddListener(FarmerAssign);
    }

    void BuilderAssign()
    {
        unitScr.SelectRole(Role.builder);
    }

    void FarmerAssign()
    {
        unitScr.SelectRole(Role.farmer);
    }

    void WarriorAssign()
    {
        unitScr.SelectRole(Role.soldier);
    }
}
