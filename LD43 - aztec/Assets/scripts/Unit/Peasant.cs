using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant : UnitBase
{
    //--[ Fields ]--------------------------------------------------------- 

    [SerializeField]
    private float productionMultiplier = 0.1f;

    //--[ Changed virtual methods ]----------------------------------------

    public override BuildingBase.Type SuitableBuildingType() { return BuildingBase.Type.farm; }

    public virtual new float Production()
    {
        if( workplace.GetComponent<BuildingBase>().BuildingType() == SuitableBuildingType())
        {
            return 1f + (level * productionMultiplier);
        }
        else
        {
            return base.Production();
        }
    }
}
