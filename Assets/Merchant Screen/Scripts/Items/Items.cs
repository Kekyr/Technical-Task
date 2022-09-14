using System.Collections.Generic;
using UnityEngine;

public class Items:MonoBehaviour, IItems
{
    public List<GameObject> Subjects { get; private set;}

    private void Awake()
    {
        Subjects = new List<GameObject>();
    }
    
    public void CreateItems(List<Item> itemsPrefabs)
    {
        for (int i = 0; i < itemsPrefabs.Count; i++)
        {
            Subjects.Add(itemsPrefabs[i].Create());
        }
    }
}