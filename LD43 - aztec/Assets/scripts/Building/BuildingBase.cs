using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingBase : MonoBehaviour
{
    public enum Type
    {
        farm,
        barracks,
        workshop,
        other,
    }

    [SerializeField]
    public GameObject[] workers = new GameObject[3];


    void Start()
    {
        StartCoroutine(ProductionCoroutine());



        MyStart();
    }

    protected virtual void MyStart() { }
    public abstract Type BuildingType();
    public abstract IEnumerator ProductionCoroutine();

}