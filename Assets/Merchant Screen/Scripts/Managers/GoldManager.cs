using UnityEngine;

public class GoldManager:MonoBehaviour, IGoldManager
{
    private ITextManager _textManager;
    private Gold _gold;
    
    [SerializeField] private int _amountOfGold;
    
    private void Awake()
    {
        _textManager = GetComponent<ITextManager>();
        _gold = GetComponent<Gold>();

        CheckAmountOfGold();
    }
    
    private void CheckAmountOfGold()
    {
        if (_amountOfGold < 0)
        {
            Debug.Log("Количество золота не может быть меньше 0!");
        }
        else
        {
            UpdateCounterOfGold();
        }
    }
    
    public bool BuyItem(IItemScriptableObject itemData)
    {
        if (_amountOfGold >= itemData.Price)
        {
            _gold.BuyItem(itemData,ref _amountOfGold);
            UpdateCounterOfGold();
            return true;
        }
        
        Debug.Log("У вас недостаточно золота для покупки этого предмета!");
        return false;
    }
    
    public void SellItem(IItemScriptableObject itemData,int sellDiscount)
    {
        _gold.SellItem(itemData,ref _amountOfGold,sellDiscount);
        UpdateCounterOfGold();
    }
    
    public void UpdateCounterOfGold()
    {
        _textManager.ChangeText(_amountOfGold);
    }
    
    
}