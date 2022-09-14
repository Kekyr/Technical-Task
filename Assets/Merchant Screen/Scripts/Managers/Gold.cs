using UnityEngine;

public class Gold:MonoBehaviour
{
    public void BuyItem(IItemScriptableObject itemData,ref int amountOfGold)
    {
        amountOfGold -= itemData.Price;
    }

    public void SellItem(IItemScriptableObject itemData, ref int amountOfGold,int sellDiscount)
    {
        amountOfGold += itemData.Price - sellDiscount;
    }
}