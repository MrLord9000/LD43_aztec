using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SceneManager : MonoBehaviour {

    public bool stopHouseBuilding = false;
    public float buildingTime;

    public GameObject manPrefab;
    public List<GameObject> units;
    public List<GameObject> houses;

    private Board b;

    private SpawnRandomGrid srg;
    private SpawnRandomUnit sru;

    private void Awake()
    {
        b = Resources.Load<Board>("boardData");
        b.lockedTiles.Clear();
        b.lockedTiles.Add(new Vector2(1, 1));
        b.lockedTiles.Add(new Vector2(-1, 1));
        b.lockedTiles.Add(new Vector2(1, -1));
        b.lockedTiles.Add(new Vector2(-1, -1));
        b.lockedTiles.Add(new Vector2(-2, -2)); //for workers 
        b.lockedTiles.Add(new Vector2(-2, -1));
        b.lockedTiles.Add(new Vector2(-1, -2));
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
                b.unitSpawnTimeLeft -= b.nFarmers;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator HouseBuilding()
    {
        while(true)
        {
            if(!stopHouseBuilding)
            {
                if (b.buildingTimeLeft <= 0f)
                {
                    b.buildingTimeLeft = b.buildingTimeCost;
                    srg.BuildingSpawner();
                }
                else
                {
                    b.buildingTimeLeft -= b.nWorkers;
                }
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
