using System.Collections.Generic;
using UnityEngine;

public class Slots:MonoBehaviour, ISlots
{
    public List<GameObject> Cells { get; private set; }

    private void Awake()
    {
        Cells = new List<GameObject>();
    }
    
    public void AddSlots(GameObject grid, int childCount)
    {
        for (int i = 0; i < childCount; i++)
        {
            Cells.Add(grid.transform.GetChild(i).gameObject);
        }
    }
    
    public void FillOutSlots(List<GameObject> items)
    {
        for(int i=0; i<items.Count; i++)
        {
            items[i].transform.SetParent(Cells[i].transform,false);
        }
    }
    
    public Slot FindFirstFreeSlot()
    {
        foreach (GameObject slot in Cells)
        {
            if (IsSlotFree(slot))
            {
                return slot.GetComponent<Slot>();
            }
        }

        return null;
    }

    public bool IsSlotFree(GameObject slot)
    {
        return slot.transform.childCount == 0;
    }
}
