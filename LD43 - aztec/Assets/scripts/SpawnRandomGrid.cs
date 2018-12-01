using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomGrid : MonoBehaviour {

    public Vector2Int gridSize;
    public Vector2Int maxRangeSpawn;
    public Vector2Int templeSpaceOffset;

    public GameObject[] prefabToSpawn;

    private int mapSize;
    private Vector2 spawnPlace;
    private int posX, posY;
    [SerializeField]
    private int maxExpansion = 1;
    private int buildingNumber = 0;
    private List<int> buildingOrbit;
    private List<Vector2> buildingList;

    private void Start()
    {
        buildingOrbit = new List<int>();
        buildingList = new List<Vector2>();
        buildingList.Add(new Vector2(1, 1));
        buildingList.Add(new Vector2(-1, 1));
        buildingList.Add(new Vector2(1, -1));
        buildingList.Add(new Vector2(-1, -1));
        buildingOrbit.Add(0);
        mapSize = (2 * maxRangeSpawn.x + 1) * (2 * maxRangeSpawn.y + 1);
        StartCoroutine("BuildingSpawner");
    }
    
    private IEnumerator BuildingSpawner()
    {
        while (true)
        {
            bool again = false;
            do
            {
                posX = Random.Range(-maxExpansion, maxExpansion + 1) * gridSize.x + 1;
                posY = Random.Range(-maxExpansion, maxExpansion + 1) * gridSize.y + 1;

                spawnPlace = new Vector2(posX, posY);

                    if (buildingList.Contains(spawnPlace) && buildingNumber < mapSize) again = true;
                    else
                    {
                        again = false;
                        buildingList.Add(spawnPlace);
                        buildingNumber++;
                        buildingOrbit[maxExpansion - 1]++;
                    }

                if (maxExpansion * 3 < buildingOrbit[maxExpansion - 1])
                {
                    maxExpansion++;
                    buildingOrbit.Add(0);
                }
                    
                
            } while (again);

            Instantiate(prefabToSpawn[Random.Range(0, 2)], spawnPlace, new Quaternion(0, 0, 0, 0));

            yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
        }
    }
    
}