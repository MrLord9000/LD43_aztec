using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{
    house,
    workshop,
    farm,
    fort
}
public class Building : MonoBehaviour {


    public BuildingType type;

    public Sprite houseSprite;
    public Sprite workshopSprite;
    public Sprite farmSprite;
    public Sprite fortSprite;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private int capacity;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = houseSprite;
        type = BuildingType.house;
        capacity = 2;
	}
    public void SetType(BuildingType type)
    {
        switch(type)
        {
            case BuildingType.house:
                spriteRenderer.sprite = houseSprite;
                capacity = 2;
                return;
            case BuildingType.workshop:
                spriteRenderer.sprite = workshopSprite;
                capacity = 1;
                return;
            case BuildingType.farm:
                spriteRenderer.sprite = farmSprite;
                capacity = 1;
                return;
            case BuildingType.fort:
                spriteRenderer.sprite = fortSprite;
                capacity = 1;
                return;
        }
    }
}
