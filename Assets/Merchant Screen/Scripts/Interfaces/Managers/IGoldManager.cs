public interface IGoldManager
{
    bool BuyItem(IItemScriptableObject itemData);
    void SellItem(IItemScriptableObject itemData, int sellDiscount);
    void UpdateCounterOfGold();
}