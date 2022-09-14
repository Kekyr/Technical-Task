using UnityEngine;
using UnityEngine.UI;

public interface IItem
{
    ItemScriptableObject Data { get;}

    Drag Drag { get; }
    Image Image { get;}
    bool IsItemInSlot();
    void ChangePosition(Vector3 newPosition);
    void ChangeParent(Transform newParent);
    void AlingItemWithNewSlot();
    void DisplayItemOnAnotherGrid();

    void TurnOnAndOffMouseEvents(bool turn);

    Vector3 GetItemPosition();
}