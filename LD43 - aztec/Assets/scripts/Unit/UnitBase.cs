using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

//--[ ---------------------------------------------------------------------



//--[ Main Class ]---------------------------------------------------------

public class UnitBase : MonoBehaviour
{
    //--[ Fields ]--------------------------------------------------------- 
    

    [SerializeField]
    private string unitName;  // name jest dziedziczone z MonoBehaviour

    [SerializeField]
    protected int level = 0;

    // zmienić typ gdy właściwy skrypt będzie gotowy
    public GameObject workplace;

    [SerializeField]
    Exp exp = new Exp();

    //--[ Unity Functions ]------------------------------------------------

    void Start()
    {
        GameManager.units.Add(this.gameObject);
        StartCoroutine(ExpCoroutine());
    }

    //--[ Inline virtual methods ]-----------------------------------------

    public virtual BuildingBase.Type SuitableBuildingType { get => BuildingBase.Type.other; }
    public virtual void LvlUp() { level++; }

    //--[ Inline non-virtual methods ]-------------------------------------

    public BuildingBase.Type CurrentWorkplaceType { get => workplace.GetComponent<BuildingBase>().BuildingType(); }// <- w przyszłości poprawić

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
            try
            {
                

                if (CurrentWorkplaceType == SuitableBuildingType)
                {
                    if (exp[CurrentWorkplaceType] >= GameManager.expRequiredToLevelUp)
                    {
                        exp[CurrentWorkplaceType] = 0;
                        level++;
                    }

                    exp[CurrentWorkplaceType]++;
                }
                else
                {
                    if (exp[CurrentWorkplaceType] < GameManager.expRequiredToLevelUp)
                    {
                        exp[CurrentWorkplaceType]++;
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
