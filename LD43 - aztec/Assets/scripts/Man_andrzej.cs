/*ing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Age
{
    child,
    adult,
    old
}

public enum Sex
{
    female,
    male
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

public class Man : MonoBehaviour
{
    public int expRequire;
    public GameObject house;
    public int slotInHouse;

    [System.Serializable]
    public class Level
    {
        public bool isWorking = false;
        public int level = 0;
        public int exp = 0;
    }

    public string _name;

    public Sex sex;
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

        StartCoroutine(ExpCoroutine(builder, Role.builder));
        StartCoroutine(ExpCoroutine(farmer, Role.farmer));
        StartCoroutine(ExpCoroutine(soldier, Role.soldier));
    }

    void Update()
    {


    }

    void SetRole( Role set )
    {
        role = set;
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
}*/
