using System.Collections.Generic;
using UnityEngine;

public interface ISlots
{
    List<GameObject> Cells { get; }
    void AddSlots(GameObject grid, int childCount);
    void FillOutSlots(List<GameObject> items);
    Slot FindFirstFreeSlot();
    bool IsSlotFree(GameObject slot);
}