using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomGrid : MonoBehaviour
{

    public Vector2Int gridSize;
    public Vector2Int maxRangeSpawn;
    public float vari = .2f;
    public GameObject prefabToSpawn;

    private int mapSize;
    private Vector2 spawnPlace;
    private int posX, posY;
    [SerializeField]
    private int maxExpansion = 1;
    private int buildingNumber = 0;
    private List<int> buildingOrbit;
    public Board b;

    private void Awake()
    {
        buildingOrbit = new List<int>();
        b.lockedTiles.Add(new Vector2(1, 1));
        b.lockedTiles.Add(new Vector2(-1, 1));
        b.lockedTiles.Add(new Vector2(1, -1));
        b.lockedTiles.Add(new Vector2(-1, -1));
        buildingOrbit.Add(0);
        mapSize = (2 * maxRangeSpawn.x + 1) * (2 * maxRangeSpawn.y + 1);
    }

    public void BuildingSpawner()
    {
        bool again = false;
        //print("qwerty");
        do
        {
            posX = Random.Range(-maxExpansion, maxExpansion + 1) * gridSize.x + 1;
            posY = Random.Range(-maxExpansion, maxExpansion + 1) * gridSize.y + 1;

            spawnPlace = new Vector2(posX, posY);

            if (b.lockedTiles.Contains(spawnPlace) && buildingNumber < mapSize)
            {
                again = true;
            }
            else
            {
                again = false;
                b.lockedTiles.Add(spawnPlace);
                buildingNumber++;
                buildingOrbit[maxExpansion - 1]++;
            }

            spawnPlace = new Vector2(posX + Random.Range(-vari, vari), posY + Random.Range(-vari, vari));

            if (maxExpansion * 3 < buildingOrbit[maxExpansion - 1])
            {
                maxExpansion++;
                buildingOrbit.Add(0);
            }


        } while (again);

        Instantiate(prefabToSpawn, spawnPlace, new Quaternion(0, 0, 0, 0));

    }

}