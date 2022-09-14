using System.Collections.Generic;
using UnityEngine;

public interface IItems
{
    List<GameObject> Subjects { get; }

    void CreateItems(List<Item> itemsPrefabs);
}