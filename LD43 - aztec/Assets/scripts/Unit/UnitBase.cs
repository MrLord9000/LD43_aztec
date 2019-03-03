using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--[ ---------------------------------------------------------------------



//--[ Main Class ]---------------------------------------------------------

public class UnitBase : MonoBehaviour
{
    //--[ Fields ]--------------------------------------------------------- 

    [SerializeField]
    private GridData gridData;

    private int expRequiredToLevelUp = 100;

    [SerializeField]
    private string unitName;  // name jest dziedziczone z MonoBehaviour

    [SerializeField]
    protected int level = 0;

    // zmienić typ gdy właściwy skrypt będzie gotowy
    public GameObject workplace;

    [SerializeField]
    Exp exp;

    void Start()
    {
        StartCoroutine(ExpCoroutine());
    }

    //--[ Inline virtual methods ]-----------------------------------------

    public virtual BuildingBase.Type SuitableBuildingType() { return BuildingBase.Type.other; }
    public virtual void LvlUp() { level++; }
    

    //--[ Long virtual methods]--------------------------------------------

    public virtual float Production()
    {
        return 1f;
    }

    //--[ Long non-virtual methods ]---------------------------------------

    private IEnumerator ExpCoroutine()
    {
        while (true)
        {
            BuildingBase.Type currentBT = BuildingBase.Type.other;

            try
            {
                currentBT = workplace.GetComponent<BuildingBase>().BuildingType();

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
            catch (UnassignedReferenceException) { }
            catch (System.NullReferenceException) { }

            yield return new WaitForSeconds(1f);
        }
    }

}

//--[ Support Classes ]----------------------------------------------------

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

    public int this[BuildingBase.Type key]
    {
        get
        {
            switch (key)
            {
                case BuildingBase.Type.farm:
                    return peasant;
                case BuildingBase.Type.workshop:
                    return worker;
                case BuildingBase.Type.barracks:
                    return soldier;
                default:
                    return -1;
            }
        }

        set
        {
            switch (key)
            {
                case BuildingBase.Type.farm:
                    peasant = value;
                    break;
                case BuildingBase.Type.workshop:
                    worker = value;
                    break;
                case BuildingBase.Type.barracks:
                    soldier = value;
                    break;
            }
        }
    }

}
