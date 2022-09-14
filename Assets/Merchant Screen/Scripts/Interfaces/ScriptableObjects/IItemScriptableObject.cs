using UnityEngine;

public interface IItemScriptableObject
{
    int Price { get; }
    Sprite Sprite { get; }
    bool CheckData();
    bool CheckSellPrice();
}