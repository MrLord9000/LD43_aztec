using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Man : MonoBehaviour
{

    public int expRequire;

    public enum Age
    {
        child,
        adult,
        old
    }
    public enum Role
    {
        worker,

        builder,
        farmer,
        soldier
    }
    public enum Variant
    {
        none,
        _1,
        _2,
        _3
    }
    [System.Serializable]
    public class Level
    {
        public bool isWorking = false;
        public int level = 0;
        public int exp = 0;
    }

    public string _name;
    public Role role;
    public Variant variant = Variant.none;

    [Space]

    public Level builder = new Level();
    public Level farmer = new Level();
    public Level soldier = new Level();

    [Space]
    [SerializeField]
    private int age = 0;
    [SerializeField]
    private Age enumAge = Age.child;
    
    private int old;
    private int dead;

    void Start()
    {
        old = (int)Random.Range(12, 16);
        old = (int)Random.Range(17, 22);

        StartCoroutine(ExpCoroutine(builder,Role.builder));
        StartCoroutine(ExpCoroutine(farmer, Role.farmer));
        StartCoroutine(ExpCoroutine(soldier, Role.soldier));
    }

    void Update()
    {

    }

    IEnumerator ExpCoroutine(Level x, Role y)
    {
        while (x.level < 10)
        {
            if ( x.isWorking && (x.level != 3 || role == y) )
            {
                if (role != Role.worker && role != y) yield break;

                x.exp++;

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

    void SetVariant()
    {
        int rand = (int)Random.Range(1, 4);
        
        switch(rand)
        {
            case 1:
                variant = Variant._1;
                return;
            case 2:
                variant = Variant._3;
                return;
            case 3:
                variant = Variant._3;
                return;
        }
    }
}




/*
	// Use this for initialization
	void Start ()
    {
        old = (int)Random.Range(12, 16);
        old = (int)Random.Range(17, 22);

        StartCoroutine(Work(Role.builder));
        StartCoroutine(Work(Role.farmer));
        StartCoroutine(Work(Role.soldier));
    }
	
	// Update is called once per frame
	void Update () {
        expirience();

        
    }

    private IEnumerator Work(Role role)
    {
        while (true)
        {
            switch (role)
            {
                case Role.builder:
                    if (work_as_builder)
                    {
                        if (builderExp >= expRequire)
                        {
                            builderExp = 0;
                            builderLevel++;
                        }
                        else
                        {
                            builderExp++;
                        }
                    }
                    break;

                case Role.farmer:
                    if (work_as_farmer)
                    {
                        if (farmerExp >= expRequire)
                        {
                            farmerExp = 0;
                            farmerLevel++;
                        }
                        else
                        {
                            farmerExp++;
                        }
                    }
                    break;

                case Role.soldier:
                    if (work_as_soldier)
                    {
                        if (soldierExp >= expRequire)
                        {
                            soldierExp = 0;
                            soloderLevel++;
                        }
                        else
                        {
                            soldierExp++;
                        }
                    }
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void expirience()
    {
        if (isMaxed) return;

        switch (role)
        {
            case Role.builder:
                if (builderLevel >= 10)
                {
                    isMaxed = true;
                    StopCoroutine(Work(Role.builder));
                    builderExp = 0;
                }
                StopCoroutine(Work(Role.farmer));
                StopCoroutine(Work(Role.soldier));
                work_as_farmer = false;
                work_as_soldier = false;
                return;

            case Role.farmer:
                if (farmerLevel >= 10)
                {
                    isMaxed = true;
                    StopCoroutine(Work(Role.farmer));
                    farmerExp = 0;
                }
                StopCoroutine(Work(Role.builder));
                StopCoroutine(Work(Role.soldier));
                work_as_builder = false;
                work_as_soldier = false;
                return;

            case Role.soldier:
                if (soloderLevel >= 10)
                {
                    isMaxed = true;
                    StopCoroutine(Work(Role.soldier));
                    soldierExp = 0;
                }
                StopCoroutine(Work(Role.farmer));
                StopCoroutine(Work(Role.builder));
                work_as_builder = false;
                work_as_farmer = false;
                return;

            case Role.worker:
                if (builderLevel >= 4)
                {
                    builderLevel = 4;
                    builderExp = 0;
                }
                if (farmerLevel >= 4)
                {
                    farmerLevel = 4;
                    farmerExp = 0;
                }
                if (soloderLevel >= 4)
                {
                    soloderLevel = 4;
                    soldierExp = 0;
                }
                break;
        }
    }
}
*/
