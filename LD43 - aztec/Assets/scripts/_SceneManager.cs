using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SceneManager : MonoBehaviour {

    public GameObject manPrefab;
    public List<GameObject> units;
    public List<GameObject> houses;

    public float buildingTimeCost = 100.0f;
    public float buildingTimeLeft = 0f;

    private SpawnRandomGrid srg;

    private void Start()
    {
        srg = GetComponent<SpawnRandomGrid>();
        StartCoroutine("HouseBuilding");
    }

    private void Update()
    {
        
    }

    void CreateUnit()
    {
        GameObject temp = Instantiate(manPrefab, new Vector2(0, 0), new Quaternion());
        units.Add( temp );
    }

    int CalculateBuildForce()
    {
        
        return 0;
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
                buildingTimeLeft -= 10f;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
