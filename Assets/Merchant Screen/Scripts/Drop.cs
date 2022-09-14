using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour,IDropHandler
{
    private Grid _grid;
    private Slot _newParent;
    private Item _item;

    private void Start()
    {
        _grid = GetComponent<Grid>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop!");
        _newParent = _grid.Slots.FindFirstFreeSlot();
        _item = eventData.pointerDrag.GetComponent<Item>();
        IsFreeSlotFound(_item, _newParent);
    }
    
    private void IsFreeSlotFound(Item item, Slot newParent)
    {
        if (newParent != null)
        {
            CheckParentOfItem(item, newParent);
        }
        else
        {
            Debug.Log("В сетке предметов " + gameObject.name + " нет свободного слота!");
        }
    }
    
    private void CheckParentOfItem(Item item, Slot newParent)
    {
        if (!IsGameObjectParentOfItem(item.transform.parent))
        {
            Debug.Log("Данный предмет " + item.name + " из другой сетки предметов!");
            _grid.CheckGrid(item, newParent);
        }
    }
    
    private bool IsGameObjectParentOfItem(Transform parentOfItem)
    {
        return Helper.ComparePoints(parentOfItem.position, gameObject.transform.position,0.01f);
    }
    
}