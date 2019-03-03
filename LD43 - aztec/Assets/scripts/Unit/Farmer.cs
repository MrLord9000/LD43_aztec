using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class Farmer : Peasant
{
    public float Bonus{ get => CurrentWorkplaceType == SuitableBuildingType ? GameManager.FarmerGlobalProductionBonus * (level-GameManager.specializationLevel) : 0; }

}
