using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPORARY_Sacrefice : MonoBehaviour {

    public int godsAnger = 100;

	public void Sacrefice(Unit unit)
    {
        int value = 0;
        value += unit.builderLevel.level;
        if (unit.builderLevel.level > 3) value += unit.builderLevel.level - 3;
        if (unit.builderLevel.level > 6) value += unit.builderLevel.level - 6;

        value += unit.farmerLevel.level;
        if (unit.farmerLevel.level > 3) value += unit.farmerLevel.level - 3;
        if (unit.farmerLevel.level > 6) value += unit.farmerLevel.level - 6;

        value += unit.soldierLevel.level;
        if (unit.soldierLevel.level > 3) value += unit.soldierLevel.level - 3;
        if (unit.soldierLevel.level > 6) value += unit.soldierLevel.level - 6;

        godsAnger -= value;

        unit.Die();
    }
}
