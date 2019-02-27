
#define UNITY_EDITOR 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using HumanStats;

public enum Age { child, adult, old }
public enum Sex { female, male }
public enum Role { worker, builder, farmer, soldier }
public enum Variant { none, _1, _2, _3 }

public class Unit : MonoBehaviour {

    private GameObject gameController;
    private UnitStatistics stats;
    public GameObject workplace;

    public int expRequire;
    public GameObject house;
    public int slotInHouse;

    public Level builderLevel = new Level();
    public Level farmerLevel = new Level();
    public Level soldierLevel = new Level();
    private bool roleIsAssigned = false;

    public Age lifeTime;
    public float lifetimeUnassigned = 20f;
    private float maxLifetimeUnassigned;
    public float lifetimeAssigned = 1000f;
    public float lifetimeOld = 300f;

    public Sex sex;
    public Role role;
    public Variant variant = Variant.none;
    public int Level;

    private Button timeBar;
    private SpriteRenderer spriteRenderer;

    public HumanStat productivity;
    public StatModifier modifier;

    private void Start()
    {
        productivity = new HumanStat(0f);

	    gameController = GameObject.FindGameObjectWithTag("GameController");
        stats = gameController.GetComponent<UnitStatistics>();

        stats.NumberOf_Units++;
        stats.NumberOf_Childern++;

        stats.listOfAllUnits.Add(this);

        //productivity.BaseValue = 0f;
        Level = 1;

        int tmp = (int)Random.Range(0, 2);
        
        if( tmp == 0)
        {
            sex = Sex.male;
            stats.NumberOf_Males++;
        }
        else
        {
            sex = Sex.female;
            stats.NumberOf_Females++;
        }


        //stats = gameController.GetComponent<UnitStatistics>();
        //stats.listOfAllUnits.Add(this);

        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector2(1f, 1f);
        maxLifetimeUnassigned = lifetimeUnassigned;
        timeBar = GetComponentInChildren<Button>();

        StartCoroutine(ExpCoroutine(builderLevel, Role.builder));
        StartCoroutine(ExpCoroutine(farmerLevel, Role.farmer));
        StartCoroutine(ExpCoroutine(soldierLevel, Role.soldier));
    }

    private void FixedUpdate()
    {
        switch(lifeTime)
        {
            case Age.child:
                if (lifetimeUnassigned <= 0)
                {
                    Die();
                }
                lifetimeUnassigned -= Time.deltaTime;
                timeBar.image.fillAmount = lifetimeUnassigned / maxLifetimeUnassigned;
                break;

            case Age.adult:
                timeBar.gameObject.SetActive(false); //TEMPORARY!
                if (lifetimeAssigned <= 0)
                {
                    spriteRenderer.color = new Color(255f, 114f, 114f);
                    lifeTime = Age.old;
                    stats.NumberOf_Adults--;
                    stats.NumberOf_Olds++;
                }
                lifetimeAssigned -= Time.deltaTime;
                break;

            case Age.old:
                if (lifetimeOld <= 0) Die();
                lifetimeOld -= Time.deltaTime;
                break;
        }
        


        if (workplace != null)
        {
            if (lifeTime == Age.child) lifeTime = Age.adult;
            Work(workplace.GetComponentInParent<Building>().type);
        }
        else
        {
            builderLevel.isWorking = false;
            farmerLevel.isWorking = false;
            soldierLevel.isWorking = false;
        }
    }

    void Work(BuildingType workplace)
    {
        switch (workplace)
        {
            case BuildingType.workshop:
                Debug.Log("working in " + workplace);
                builderLevel.isWorking = true;
                farmerLevel.isWorking = false;
                soldierLevel.isWorking = false;


                return;

            case BuildingType.farm:
                Debug.Log("working in " + workplace);
                builderLevel.isWorking = false;
                farmerLevel.isWorking = true;
                soldierLevel.isWorking = false;


                return;

            case BuildingType.fort:
                Debug.Log("working in " + workplace);
                builderLevel.isWorking = false;
                farmerLevel.isWorking = false;
                soldierLevel.isWorking = true;


                return;

            case BuildingType.house:
                Debug.Log("working in " + workplace);
                builderLevel.isWorking = false;
                farmerLevel.isWorking = false;
                soldierLevel.isWorking = false;


                return;
        }

    }

    IEnumerator ExpCoroutine(Level x, Role y)
    {
        float[] buffs = { 0f, 0f, 0f, 01f, 02f, 0.3f, 0.4f, 0.6f, 0.8f, 1f };

        while (x.level < 10)
        {
            if (x.isWorking && (x.level != 3 || role == y))
            {
                if (role != Role.worker && role != y)
                {   
                    /*switch(role)
                    {
                        case Role.builder:
                            //Destroy(farmerLevel);
                            break;
                        case Role.farmer:
                            break;
                        case Role.soldier:
                            break;
                    }*/

                    yield break;
                }

                x.exp++;

                productivity.AddModifier(new StatModifier(buffs[Level-1], StatModType.PercentAdd));
                UpdateGlobalProductivity();

                if (x.exp == expRequire)
                {
                    x.exp = 0;
                    x.level++;
                }

                if (x.level == 6 && variant == Variant.none) SetVariant();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SelectRole(Role role)
    {
        if ( roleIsAssigned || role == Role.worker ) return;

        productivity.AddModifier(new StatModifier(1f, StatModType.Flat));

        this.role = role;

        roleIsAssigned = true;
        stats.NumberOf_Workers--;

        switch(role)
        {
            case Role.builder:
                stats.NumberOf_Builders++;
                break;
            case Role.farmer:
                stats.NumberOf_Farmers++;
                break;
            case Role.soldier:
                stats.NumberOf_Soldiers++;
                break;
        }

        modifier = new StatModifier(productivity.Value, StatModType.Flat,this);
        switch(role)
        {
            case Role.builder:
                stats.BuildersProductivity.AddModifier(modifier);
                break;
            case Role.farmer:
                stats.FarmersProductivity.AddModifier(modifier);
                break;
            case Role.soldier:
                stats.SoldiersProductivity.AddModifier(modifier);
                break;
        }

        GetComponent<ManSprite>().UpdateSprite();
    }

    private void UpdateGlobalProductivity()
    {
        switch (role)
        {
            case Role.builder:
                stats.BuildersProductivity.RemoveAllModifiersFromSource(this);
                stats.BuildersProductivity.AddModifier(modifier);
                break;
            case Role.farmer:
                stats.FarmersProductivity.RemoveAllModifiersFromSource(this);
                stats.FarmersProductivity.AddModifier(modifier);
                break;
            case Role.soldier:
                stats.SoldiersProductivity.RemoveAllModifiersFromSource(this);
                stats.SoldiersProductivity.AddModifier(modifier);
                break;
        }
    }

    void SetVariant()
    {
        int rand = (int)Random.Range(1, 4);

        switch (rand)
        {
            case 1:
                variant = Variant._1;
                switch(role)
                {
                    case Role.builder:
                        stats.NumberOf_Builders1++;
                        break;
                    case Role.farmer:
                        stats.NumberOf_Farmers1++;
                        break;
                    case Role.soldier:
                        stats.NumberOf_Soldiers1++;
                        break;
                }
                return;
            case 2:
                variant = Variant._2;
                switch (role)
                {
                    case Role.builder:
                        stats.NumberOf_Builders2++;
                        break;
                    case Role.farmer:
                        stats.NumberOf_Farmers2++;
                        break;
                    case Role.soldier:
                        stats.NumberOf_Soldiers2++;
                        break;
                }
                return;
            case 3:
                variant = Variant._3;
                switch (role)
                {
                    case Role.builder:
                        stats.NumberOf_Builders3++;
                        break;
                    case Role.farmer:
                        stats.NumberOf_Farmers3++;
                        break;
                    case Role.soldier:
                        stats.NumberOf_Soldiers3++;
                        break;
                }
                return;
        }

        productivity.AddModifier(new StatModifier(1f, StatModType.Flat));

        GetComponent<ManSprite>().UpdateSprite();

    }

    public void Die()
    {
        stats.listOfAllUnits.Remove(this);

        stats.NumberOf_Units--;

        switch(role)
        {
            case Role.worker:
                stats.NumberOf_Workers--;
                break;
            case Role.builder:
                stats.BuildersProductivity.RemoveAllModifiersFromSource(this);
                stats.NumberOf_Builders--;
                switch (variant)
                {
                    case Variant._1:
                        stats.NumberOf_Builders1--;
                        break;
                    case Variant._2:
                        stats.NumberOf_Builders2--;
                        break;
                    case Variant._3:
                        stats.NumberOf_Builders3--;
                        break;
                }
                break;
            case Role.farmer:
                stats.FarmersProductivity.RemoveAllModifiersFromSource(this);
                stats.NumberOf_Farmers--;
                switch (variant)
                {
                    case Variant._1:
                        stats.NumberOf_Farmers1--;
                        break;
                    case Variant._2:
                        stats.NumberOf_Farmers2--;
                        break;
                    case Variant._3:
                        stats.NumberOf_Farmers3--;
                        break;
                }
                break;
            case Role.soldier:
                stats.SoldiersProductivity.RemoveAllModifiersFromSource(this);
                stats.NumberOf_Soldiers--;
                switch (variant)
                {
                    case Variant._1:
                        stats.NumberOf_Soldiers1--;
                        break;
                    case Variant._2:
                        stats.NumberOf_Soldiers2--;
                        break;
                    case Variant._3:
                        stats.NumberOf_Soldiers3--;
                        break;
                }
                break;
        }

        switch (lifeTime)
        {
            case Age.child:
                stats.NumberOf_Childern--;
                break;
            case Age.adult:
                stats.NumberOf_Adults--;
                break;
            case Age.old:
                stats.NumberOf_Olds--;
                break;
        }

        if (sex == Sex.male) stats.NumberOf_Males--;
        else stats.NumberOf_Females--;

        Destroy(this.gameObject);
    }
    //------------------------------------------------------------------------------



}

[System.Serializable]
public class Level
{
    public bool isWorking = false;
    public int level = 0;
    public int exp = 0;
}

