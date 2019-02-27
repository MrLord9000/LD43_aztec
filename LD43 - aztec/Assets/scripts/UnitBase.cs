using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sex
{
    male,
    female,
}

[System.Serializable]
public class Exp
{
    [SerializeField]
    private int peasant = 0;
    [SerializeField]
    private int worker = 0;
    [SerializeField]
    private int soldier = 0;

    public int this[Building.Type key]
    {
        get
        {
            switch (key)
            {
                case Building.Type.farm:
                    return peasant;
                case Building.Type.workshop:
                    return worker;
                case Building.Type.barracks:
                    return soldier;
                default:
                    return -1;
            }
        }

        set
        {
            switch (key)
            {
                case Building.Type.farm:
                    peasant = value;
                    break;
                case Building.Type.workshop:
                    worker = value;
                    break;
                case Building.Type.barracks:
                    soldier = value;
                    break;
            }
        }
    }

}


public class UnitBase : MonoBehaviour
{
    private int expRequiredToLevelUp = 100;

    [SerializeField]
    private string unitName;  // name jest dziedziczone z MonoBehaviour

    [SerializeField]
    private int level = 0;

    // zmienić typ gdy właściwy skrypt będzie gotowy
    public GameObject workplace;

    [SerializeField]
    Exp exp;

    void Start()
    {
        StartCoroutine(ExpCoroutine());
    }


    public virtual Building.Type SuitableBuildingType() { return Building.Type.other; }


    IEnumerator ExpCoroutine()
    {
        while (true)
        {
            Building.Type currentBT = Building.Type.other;

            try
            {
                currentBT = workplace.GetComponent<Building>().BuildingType();

                if (currentBT == SuitableBuildingType())
                {
                    if (exp[currentBT] >= expRequiredToLevelUp)
                    {
                        exp[currentBT] = 0;
                        level++;
                    }

                    exp[currentBT]++;
                }
                else
                {
                    if (exp[currentBT] < expRequiredToLevelUp)
                    {
                        exp[currentBT]++;
                    }
                }
            }
            catch(UnassignedReferenceException){}

            yield return new WaitForSeconds(1f);
        }
    }


    /*
    IEnumerator ExpCoroutine( Building.Type buildingType, bool experienced)
    {
        while (true)
        {
            if (workplace == null)
            {
                Debug.Log(name + "\'s ExpCoroutine ended - workplace == null");
                break;
            }

            if(buildingType != workplace.GetComponent<Building>().BuildingType())
            {
                Debug.Log(name + "\'s ExpCoroutine ended - workplace type changed");
                break;
            }

            exp[buildingType]++;

            if(exp[buildingType] >= expRequiredToLevelUp)
            {
                if (experienced)
                {
                    level++;
                    exp[buildingType] = 0;

                    Debug.Log(name + ": got lvl " + level);

                    yield return new WaitForSeconds(1f);
                }
                else
                {
                    break;
                }
            }
        }
    }
    */



}

/*
[System.Serializable]
public struct SkillLvl
{
    public enum Type
    {
        farmer,
        builder,
        soldier,
    }

    public int farmer;
    public int builder;
    public int soldier;
    

    SkillLvl( int farmerLevel, int builderLevel, int soldierLevel) {
        farmer = farmerLevel;
        builder = builderLevel;
        soldier = soldierLevel;
    }

    public void Increment( TmpBuilding workplaceReference )
    {
        if (workplaceReference == null) return;
        Debug.Log(workplaceReference.GetType().ToString());

        switch (workplaceReference.GetType().ToString())
        {
            case "Farm":
                farmer++;
                break;
            case "Barracks":
                soldier++;
                break;
            case "Workshop":
                builder++;
                break;
        }
    }

}
*/
