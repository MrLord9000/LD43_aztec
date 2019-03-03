using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workshop : BuildingBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override Type BuildingType() { return Type.workshop; }
    public override IEnumerator ProductionCoroutine()
    {
        throw new System.NotImplementedException();
    }
}