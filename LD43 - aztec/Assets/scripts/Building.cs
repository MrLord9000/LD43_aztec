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

    public int capacity;
    public int assigned;

    public Sprite houseSprite;
    public Sprite workshopSprite;
    public Sprite farmSprite;
    public Sprite fortSprite;

    public Transform[] slotsT;

    private SpriteRenderer spriteRenderer;


    public bool[] slots = {false,false,false,false,false};

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = houseSprite;
        type = BuildingType.house;
        capacity = 2;
	}
    public void SetType(BuildingType type)
    {
        switch (type)
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

    public void SetInSlot( GameObject obj)
    {
        switch (obj.GetComponent<Unit>().slotInHouse)
        {
            case 0:
                obj.transform.position = slotsT[0].position;
                break;
            case 1:
                obj.transform.position = slotsT[1].position;
                break;
            case 2:
                obj.transform.position = slotsT[2].position;
                break;
            case 3:
                obj.transform.position = slotsT[3].position;
                break;
            case 4:
                obj.transform.position = slotsT[4].position;
                break;
        }
    }
}
