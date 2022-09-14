using UnityEngine;

public interface IChangeTransform
{
    void ChangePosition(Vector3 newPosition);
    void ChangeParent(Transform newParent);

    Vector3 GetPosition();
    void DisplayItemOnAnotherGrid();

    bool IsItemInSlot();
}