using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant : UnitBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override BuildingBase.Type SuitableBuildingType() { return BuildingBase.Type.farm; }

    public virtual new float Production()
    {
        if( workplace.GetComponent<BuildingBase>().BuildingType() == SuitableBuildingType())
        {
            return 1f + (level * 0.1f);
        }
        else
        {
            return 1f;
        }
    }
}
