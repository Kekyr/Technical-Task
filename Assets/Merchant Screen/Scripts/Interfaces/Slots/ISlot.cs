using UnityEngine;

public interface ISlot
{
    IItem Item { set; }
    void CheckSlot(Vector2 startPosition);
    void PopItemFromSlot();

    Transform GetTransform();
}