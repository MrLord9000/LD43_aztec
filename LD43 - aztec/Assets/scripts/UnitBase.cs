using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sex
{
    male,
    female,
}

[System.Serializable]
public struct Exp
{
    public Building.Type key;
    public int value;
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

    public Dictionary<Building.Type, int> exp;


    void Awake()
    {
        exp = new Dictionary<Building.Type, int>
        {
            { Building.Type.farm, 0 },
            { Building.Type.workshop, 0 },
            { Building.Type.barracks, 0 },
        };
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    
    IEnumerator ExpCoroutine( Building.Type buildingType, bool expirienced)
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

            if(exp[buildingType] == 100)
            {
                if (expirienced)
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
