using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SceneManager : MonoBehaviour {

    public GameObject manPrefab;
    public List<GameObject> units;
    public List<GameObject> houses;

    public int startingUnits = 4;
    public int timeMultiplier = 1;
    public float buildingTimeCost = 100.0f;
    public float buildingTimeLeft = 0f;
    public float unitSpawnTimeCost = 200.0f;
    public float unitSpawnTimeLeft = 0f;

    private SpawnRandomGrid srg;
    private SpawnRandomUnit sru;

    private void Start()
    {
        srg = GetComponent<SpawnRandomGrid>();
        sru = GetComponent<SpawnRandomUnit>();
        for(int i = 0; i < startingUnits; i++)
        {
            sru.SpawnUnit();
        }
        StartCoroutine("HouseBuilding");
        StartCoroutine("UnitMaking");
    }

    private void Update()
    {
        
    }

    int CalculateBuildForce()
    {
        
        return 0;
    }

    IEnumerator UnitMaking()
    {
        while(true)
        {
            if (unitSpawnTimeLeft <= 0f)
            {
                unitSpawnTimeLeft = unitSpawnTimeCost;
                sru.SpawnUnit();
            }
            else
            {
                unitSpawnTimeLeft -= timeMultiplier;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator HouseBuilding()
    {
        while(true)
        {
            if (buildingTimeLeft <= 0f)
            {
                buildingTimeLeft = buildingTimeCost;
                srg.BuildingSpawner();
            }
            else
            {
                buildingTimeLeft -= timeMultiplier;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
