using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class Collector : Peasant
{
    //--[ Fields ]--------------------------------------------------------- 


    //--[ Changed virtual methods ]----------------------------------------

    public override float Production()
    {
        if (workplace.GetComponent<BuildingBase>().BuildingType() == SuitableBuildingType)
        {
            return 1f + (level * GameManager.CollectorProductionBonus);
        }
        else
        {
            return (this as UnitBase).Production();
        }
    }
}
