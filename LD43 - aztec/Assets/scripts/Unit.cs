using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Age { child, adult, old }

public class Unit : MonoBehaviour {

    
    public GameObject gameController;
    private UnitStatistics stats;

    public int expRequire;
    public GameObject house;
    public int slotInHouse;

    public Age lifeTime;
    public float lifetimeUnassigned = 20f;
    private float maxLifetimeUnassigned;
    public float lifetimeAssigned = 1000f;
    public float lifetimeOld = 300f;

    public Sex sex;
    public Role role;
    public Variant variant = Variant.none;

    private Button timeBar;
    private SpriteRenderer spriteRenderer;


    ~Unit()
    {
        //stats.listOfAllUnits;
    }

    private void Start()
    {
        stats = gameController.GetComponent<UnitStatistics>();
        //stats.listOfAllUnits.Add(this);

        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector2(1f, 1f);
        maxLifetimeUnassigned = lifetimeUnassigned;
        timeBar = GetComponentInChildren<Button>();
    }

    private void FixedUpdate()
    {
        switch(lifeTime)
        {
            case Age.child:
                if (lifetimeUnassigned <= 0)
                {
                    transform.localScale = new Vector2(1.5f, 1.5f);
                    lifeTime = Age.adult; //change this
                }
                lifetimeUnassigned -= Time.deltaTime;
                timeBar.image.fillAmount = lifetimeUnassigned / maxLifetimeUnassigned;
                break;
            case Age.adult:
                if (lifetimeAssigned <= 0)
                {
                    spriteRenderer.color = new Color(255f, 114f, 114f);
                    lifeTime = Age.old;
                }
                lifetimeAssigned -= Time.deltaTime;
                break;
            case Age.old:
                if (lifetimeOld <= 0) Destroy(this.gameObject);
                lifetimeOld -= Time.deltaTime;
                break;
        }
    }
}
