
#define UNITY_EDITOR 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingController : MonoBehaviour {

    [System.Serializable]
    public class BuildingRef
    {
        public GameObject obj;
        public BuildingType type;
    }

    public BuildingRef[] buildingsList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach(BuildingRef building in buildingsList)
        {
            Building x = building.obj.GetComponent<Building>();
            x.SetType(building.type);
        }
		
	}
}
