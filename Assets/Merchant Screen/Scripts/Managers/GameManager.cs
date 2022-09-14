using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    
    private IGoldManager _goldManager;

    [field: SerializeField] public int SellDiscount { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        _goldManager = GetComponent<IGoldManager>();
        
        CheckSellDiscount();
    }
    
    private void CheckSellDiscount()
    {
        if (SellDiscount < 1)
        {
            Debug.Log("Скидка при продаже не может быть меньше 1 !");
        }
    }
    
    public void SellGameObjectItem(IItem item, ISlot newParent)
    {
        SellItem(item.Data);
        BuyOrSellItem(item,newParent);
    }
    
    public void BuyGameObjectItem(IItem item, ISlot newParent)
    {
        if (BuyItem(item.Data))
        {
            BuyOrSellItem(item,newParent);
        }
    }
    
    private void BuyOrSellItem(IItem item, ISlot newParent)
    {
        item.ChangeParent(newParent.GetTransform());
        item.Drag.Slot=newParent;
        newParent.Item = item;
    }
    
    public bool BuyItem(IItemScriptableObject itemData)
    {
        return _goldManager.BuyItem(itemData);
    }
    
    public void SellItem(IItemScriptableObject itemData)
    {
        _goldManager.SellItem(itemData,SellDiscount);
    }
}