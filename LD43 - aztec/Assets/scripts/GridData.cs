using System;
using System.Collections.Generic;
using UnityEngine;

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
    private List<Pair> pairs;

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

[CreateAssetMenu(fileName = "GridData", menuName = "ScriptableObjects/GridData", order = 1)]
public class GridData : ScriptableObject
{
    public GridContainer gridBuildings;
}
