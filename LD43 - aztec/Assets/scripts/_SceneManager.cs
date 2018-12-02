using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SceneManager : MonoBehaviour {

    public GameObject manPrefab;
    public List<GameObject> units;
    public List<GameObject> houses;

    public Board b;

    private SpawnRandomGrid srg;
    private SpawnRandomUnit sru;

    private void Awake()
    {
        b.lockedTiles.Clear();
        b.lockedTiles.Add(new Vector2(1, 1));
        b.lockedTiles.Add(new Vector2(-1, 1));
        b.lockedTiles.Add(new Vector2(1, -1));
        b.lockedTiles.Add(new Vector2(-1, -1));
    }

    private void Start()
    {
        srg = GetComponent<SpawnRandomGrid>();
        sru = GetComponent<SpawnRandomUnit>();
        for(int i = 0; i < b.startingUnits; i++)
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
            if (b.unitSpawnTimeLeft <= 0f)
            {
                b.unitSpawnTimeLeft = b.unitSpawnTimeCost;
                sru.SpawnUnit();
            }
            else
            {
                b.unitSpawnTimeLeft -= b.timeMultiplier;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator HouseBuilding()
    {
        while(true)
        {
            if (b.buildingTimeLeft <= 0f)
            {
                b.buildingTimeLeft = b.buildingTimeCost;
                srg.BuildingSpawner();
            }
            else
            {
                b.buildingTimeLeft -= b.timeMultiplier;
                b.buildingTimeLeft -= b.timeMultiplier;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
