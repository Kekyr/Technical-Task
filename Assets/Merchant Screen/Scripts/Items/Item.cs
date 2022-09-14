using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour,IItem
{
    [field: SerializeField] public ItemScriptableObject Data { get; private set; }
    
    private ICheckData _checkItemData;
    private IChangeTransform _changeTransform;
    private IChangeRectTransform _changeRectTransform;
    private IChangeCanvasGroup _changeCanvasGroup;

    public Drag Drag { get; private set; }
    public Image Image { get; private set; }
    
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;


    private void Awake()
    {
        Image = GetComponent<Image>();
        Drag = GetComponent<Drag>();

        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();

        _checkItemData = GetComponent<ICheckData>();
        _changeTransform = GetComponent<IChangeTransform>();
        _changeRectTransform = GetComponent<IChangeRectTransform>();
        _changeCanvasGroup = GetComponent<IChangeCanvasGroup>();
    }

    private void Start()
    {
        _checkItemData.CheckSubjectData(this);
    }
    
    public void ChangePosition(Vector3 newPosition)
    {
        _changeTransform.ChangePosition(newPosition);
    }
    
    public void ChangeParent(Transform newParent)
    {
        _changeTransform.ChangeParent(newParent);
    }
    
    public void DisplayItemOnAnotherGrid()
    {
        _changeTransform.DisplayItemOnAnotherGrid();
    }
    
    public void AlingItemWithNewSlot()
    {
        _changeRectTransform.AlingItemWithNewSlot(_rectTransform);
    }
    
    public void TurnOnAndOffMouseEvents(bool turn)
    {
        _changeCanvasGroup.TurnOnAndOffMouseEvents(_canvasGroup,turn);
    }

    public Vector3 GetItemPosition()
    {
        return _changeTransform.GetPosition();
    }

    public bool IsItemInSlot()
    {
        return _changeTransform.IsItemInSlot();
    }

    public GameObject Create()
    {
        return Instantiate(gameObject);
    }
    
    
}