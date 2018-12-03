using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HumanStats;

[CreateAssetMenu(fileName = "boardData", menuName = "Board")]
public class Board : ScriptableObject {

    public List<Vector2> lockedTiles;
    public int startingUnits = 3;
    public int startingBuildings = 2;
    public int timeMultiplier = 1;
    public float buildingTimeCost = 100.0f;
    public float buildingTimeLeft = 0f;
    public float unitSpawnTimeCost = 200.0f;
    public float unitSpawnTimeLeft = 0f;

    public int nWorkers = 0;
    public int nFarmers = 0;
    public int nWarriors = 0;
    public int nUnits = 0;

    public float FarmersProductivity;
    public float BuildersProductivity;
    public float SoldiersProductivity;

}
