using UnityEngine;

public class ChangeRectTransform : MonoBehaviour,IChangeRectTransform
{
    public void AlingItemWithNewSlot(RectTransform rectTransform)
    {
        rectTransform.localPosition = Vector2.zero;
    }
}