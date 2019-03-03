﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class Peasant : UnitBase
{
    //--[ Fields ]--------------------------------------------------------- 


    //--[ Changed virtual methods ]----------------------------------------

    public override BuildingBase.Type SuitableBuildingType { get => BuildingBase.Type.farm; }

    public override float Production()
    {
        Debug.Log("AAAAAAAAAAAAAA");
        if( workplace.GetComponent<BuildingBase>().BuildingType() == SuitableBuildingType)
        {
            return 1f + (level * GameManager.PeasantProductionBonus);
        }
        else
        {
            return base.Production();
        }
    }
}
