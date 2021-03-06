﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HumanStats;

public class UnitStatistics : MonoBehaviour {

    [SerializeField]
    public List<Unit> listOfAllUnits;

    public int NumberOf_Units;

    public int NumberOf_Workers;
    public int NumberOf_Builders;
    public int NumberOf_Farmers;
    public int NumberOf_Soldiers;
                       
    public int NumberOf_Builders1;
    public int NumberOf_Builders2;
    public int NumberOf_Builders3;
                       
    public int NumberOf_Farmers1;
    public int NumberOf_Farmers2;
    public int NumberOf_Farmers3;
                       
    public int NumberOf_Soldiers1;
    public int NumberOf_Soldiers2;
    public int NumberOf_Soldiers3;

    public int NumberOf_Males;
    public int NumberOf_Females;

    public int NumberOf_Childern;
    public int NumberOf_Adults;
    public int NumberOf_Olds;

    public HumanStat FarmersProductivity;
    public HumanStat BuildersProductivity;
    public HumanStat SoldiersProductivity;

    public Board b;

    // Use this for initialization
    void Awake ()
    {
        listOfAllUnits = new List<Unit>();
        b = Resources.Load<Board>("boardData");
    }
	
	// Update is called once per frame
	void Update ()
    {
        b.FarmersProductivity = FarmersProductivity.Value;
        b.BuildersProductivity = BuildersProductivity.Value;
        b.SoldiersProductivity = SoldiersProductivity.Value;

        
    }
}
