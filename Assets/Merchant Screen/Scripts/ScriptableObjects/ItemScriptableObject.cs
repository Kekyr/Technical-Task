using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemScriptableObject : ScriptableObject, IItemScriptableObject
{
    [field: SerializeField] public int Price { get; private set; }

    [field: SerializeField] public Sprite Sprite { get; private set; }
    
    public bool CheckData()
    {
        if (Sprite!=null && CheckSellPrice())
        {
            return true;
        }
        return false;
    }
    
    public bool CheckSellPrice()
    {
        return Price - GameManager.instance.SellDiscount > 0;
    }
}
