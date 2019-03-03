using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

//--[Main Class]-------------------------------------------------------------


[CreateAssetMenu(fileName = "GridData", menuName = "ScriptableObjects/GridData", order = 1)]
public class GridData : ScriptableObject
{
    public float globalFoodAmount = 0;
    public float globalFoodIncomeMultiplier = 1;



    public GridContainer gridBuildings;



    public void Reset()
    {
        globalFoodAmount = 0;
        globalFoodIncomeMultiplier = 1;
        gridBuildings.pairs.Clear();
    }
}


//--[Additional Classes]------------------------------------------------------

[System.Serializable]
public class Pair
{
    public Vector2 position;
    public GameObject gameObject;

    public Pair(Vector2 pos, GameObject gameObj)
    {
        position = pos;
        gameObject = gameObj;
    }
}

[System.Serializable]
public class GridContainer
{
    [SerializeField]
    public List<Pair> pairs;

    public void RemoveEntry(Vector2 tilePos)
    {
        //Debug.Log("Pairs length: " + pairs.Count);
        for (int i = 0; i < pairs.Count; i++)
        {
            if(pairs[i].position == tilePos)
            {
                Debug.Log("Removing entry nr " + i);
                pairs.RemoveAt(i);
                return;
            }
        }
        throw new ElementNotFound("Tile " + tilePos);
    }

    public GameObject this[Vector2 position]
    {
        get
        {
            foreach (Pair pair in pairs)
            {
                if (pair.position == position)
                {
                    return pair.gameObject;
                }
            }
            throw new IndexOutOfRangeException();
        }

        set
        {
            for (int i = 0; i < pairs.Count; i++)
            {
                if (pairs[i].position == position)
                {
                    pairs[i].gameObject = value;
                    return;
                }
            }
            pairs.Add(new Pair(position, value));

        }
    }
}

[Serializable]
internal class ElementNotFound : Exception
{
    public ElementNotFound()
    {
    }

    public ElementNotFound(string message) : base(message)
    {
    }

    public ElementNotFound(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ElementNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
