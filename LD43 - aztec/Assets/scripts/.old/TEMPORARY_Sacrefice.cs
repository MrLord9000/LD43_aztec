using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPORARY_Sacrefice : MonoBehaviour {

    static public int godsAnger = 100;
    static public int godsAngerIntensyfies = 10;
    static public int bonusBGC = 0;

    public int TgodsAnger;
    public int TgodsAngerIntensyfies;
    public int TbonusBGC;

    private void Update()
    {
        TgodsAnger = godsAnger;
        TgodsAngerIntensyfies = godsAngerIntensyfies;
        TbonusBGC = bonusBGC;
    }

    public void Sacrefice(Unit unit)
    {
        int value = 1;
        value += unit.builderLevel.level;
        if (unit.builderLevel.level > 3) value += unit.builderLevel.level - 3;
        if (unit.builderLevel.level > 6) value += unit.builderLevel.level - 6;

        value += unit.farmerLevel.level;
        if (unit.farmerLevel.level > 3) value += unit.farmerLevel.level - 3;
        if (unit.farmerLevel.level > 6) value += unit.farmerLevel.level - 6;

        value += unit.soldierLevel.level;
        if (unit.soldierLevel.level > 3) value += unit.soldierLevel.level - 3;
        if (unit.soldierLevel.level > 6) value += unit.soldierLevel.level - 6;

        godsAnger -= value + bonusBGC;

        unit.Die();
    }

    public void EvilSacrefice(Unit unit)
    {
        int value = 1;
        if (unit.builderLevel.level > 3) value++;
        if (unit.builderLevel.level > 6) value++;

        value += unit.farmerLevel.level;
        if (unit.farmerLevel.level > 3) value++;
        if (unit.farmerLevel.level > 6) value++;

        value += unit.soldierLevel.level;
        if (unit.soldierLevel.level > 3) value++;
        if (unit.soldierLevel.level > 6) value++;

        bonusBGC += value;

        unit.Die();
    }

    public void GodsAngerIntensyfies()
    {
        godsAnger += godsAngerIntensyfies;
    }
}
