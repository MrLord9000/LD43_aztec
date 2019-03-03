using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameManagerScript : Singleton<GameManagerScript>
{
    [Header("General")]
    public GridData gridData;


    [Header("Units")]
    public int expRequiredToLevelUp = 100;
    public int specializationLevel = 5;
    [Space]
    public float PeasantProductionBonus = 0.1f;
    public float CollectorProductionBonus = 0.2f;
    public float FarmerGlobalProductionBonus = 0.05f;

    public List<GameObject> units;

    private void Awake()
    {
        gridData.Reset();
    }

    private void Update()
    {
        float actualFoodIncomeMultiplier = 1;

        foreach ( GameObject worker in units)
        {
            try
            {
                actualFoodIncomeMultiplier += worker.GetComponent<Farmer>().Bonus;
            }
            catch (UnassignedReferenceException) { }
            catch (System.NullReferenceException) { }
        }

        gridData.globalFoodIncomeMultiplier = actualFoodIncomeMultiplier;
    }

}

public static class Globals
{
    public static GameManagerScript GameManager { get { return GameManagerScript.Instance; } }
}