using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
{
    public ISlot Slot { private get; set; }
    
    private IItem _item;
    
    private Vector2 _startPosition;
    
    private void Start()
    {
        Slot = transform.parent.GetComponent<ISlot>();
        _item = GetComponent<IItem>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = _item.GetItemPosition();
        _item.DisplayItemOnAnotherGrid();
        _item.TurnOnAndOffMouseEvents(true);
        Slot.PopItemFromSlot();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        _item.ChangePosition(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Slot.CheckSlot(_startPosition);
        
        _item.TurnOnAndOffMouseEvents(false);
    }
}
