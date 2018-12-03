using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAssignIcons : MonoBehaviour {

    public GameObject icons;
    public GameObject builderIcon;
    public GameObject farmerIcon;
    public GameObject soldierIcon;

    private Unit thisUnit;


    // Use this for initialization
    void Awake () {
        builderIcon.SetActive(false);
        farmerIcon.SetActive(false);
        soldierIcon.SetActive(false);

        thisUnit = GetComponent<Unit>();
    }

    private void Update()
    {
        if (thisUnit.builderLevel.level == 3) builderIcon.SetActive(true);
        if (thisUnit.farmerLevel.level == 3)  farmerIcon.SetActive(true);
        if (thisUnit.soldierLevel.level == 3) soldierIcon.SetActive(true);

        if (thisUnit.role != Role.worker) icons.SetActive(false);
    }
}
