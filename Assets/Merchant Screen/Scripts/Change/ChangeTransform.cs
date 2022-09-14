using UnityEngine;

public class ChangeTransform:MonoBehaviour, IChangeTransform
{
    public void ChangePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
    
    public void ChangeParent(Transform newParent)
    {
        transform.SetParent(newParent);
    }
    
    public void DisplayItemOnAnotherGrid()
    {
        transform.parent.transform.parent.transform.SetAsLastSibling();
    }
    
    public bool IsItemInSlot()
    {
        return transform.parent.CompareTag("Slot");
    }
    
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    
    
}