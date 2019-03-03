using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : BuildingBase
{
    protected override void MyStart()
    {

    }

    public override Type BuildingType() { return Type.farm; }

    public override IEnumerator ProductionCoroutine()
    {
        while(true)
        {
            float actualFoodIncome = 0;

            foreach (GameObject go in workers)
            {
                try
                {

                    actualFoodIncome += go.GetComponent<UnitBase>().Production();
                }
                catch (UnassignedReferenceException) { }
                catch (System.NullReferenceException) { }
            }

            Debug.Log(Time.frameCount.ToString() + ' ' + actualFoodIncome.ToString());
            gridData.globalFoodAmount += actualFoodIncome * gridData.globalFoodIncomeMultiplier;

            yield return new WaitForSeconds(1f);
        }
    }
}
