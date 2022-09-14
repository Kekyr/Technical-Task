using UnityEngine;

public class ChangeItemView:MonoBehaviour, IChangeView
{
    public void ChangeSprite(IItem item)
    {
        item.Image.sprite = item.Data.Sprite;
    }
}