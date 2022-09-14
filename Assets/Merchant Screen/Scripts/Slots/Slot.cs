using UnityEngine;

public class Slot : MonoBehaviour, ISlot
{
    public IItem Item { private get; set; }

    private void Start()
    {
        Item = GetComponentInChildren<IItem>();
    }
    
    public void CheckSlot(Vector2 startPosition)
    {
        if (Item.IsItemInSlot())
        {
            Item.AlingItemWithNewSlot();
        }
        else
        {
            Item.ChangePosition(startPosition);
            Item.ChangeParent(transform);
        }
    }
    
    public void PopItemFromSlot()
    {
        Item.ChangeParent(transform.parent);
    }

    public Transform GetTransform()
    {
        return transform;
    }
    
}