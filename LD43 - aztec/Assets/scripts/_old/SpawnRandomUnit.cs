using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomUnit : MonoBehaviour {

    public GameObject prefabToSpawn;
    public Vector2 gridSize = new Vector2(2, 2);

    public void SpawnUnit()
    {
        float posX = Random.Range(-4, 5) * gridSize.x + 1;
        float posY = Random.Range(-4, 5) * gridSize.y + 1;

        Vector2 spawnPlace = new Vector2(posX, posY);

        Instantiate(prefabToSpawn, spawnPlace, new Quaternion(0, 0, 0, 0));
    }

}
