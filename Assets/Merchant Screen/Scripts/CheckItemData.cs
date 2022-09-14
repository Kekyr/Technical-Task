using UnityEngine;

public class CheckItemData : MonoBehaviour, ICheckData
{
    private IChangeView _changeItemView;

    private void Awake()
    {
        _changeItemView = GetComponent<IChangeView>();
    }
    
    public void CheckSubjectData(IItem item)
    {
        if (item.Data != null)
        {
            CheckData(item);
        }
        else
        {
            Debug.Log("Нет данных о предмете " + gameObject.name + " !");
        }
    }
    
    public void CheckData(IItem item)
    {
        if (item.Data.CheckData())
        {
            _changeItemView.ChangeSprite(item);
        }
        else
        {
            Debug.Log("Неверные данные о предмете "+name+" !");
        }
    }
    
}