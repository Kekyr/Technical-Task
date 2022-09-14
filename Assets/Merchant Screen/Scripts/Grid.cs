using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private List<Item> _itemsPrefabs;

    public ISlots Slots { get; private set; }

    private IItems _items;
    
    private void Awake()
    {
        Initialization();
        CheckData();
        _items.CreateItems(_itemsPrefabs);
        Slots.AddSlots(gameObject,transform.childCount);
        Slots.FillOutSlots(_items.Subjects);
    }

    private void Initialization()
    {
        Slots = GetComponent<ISlots>();
        _items = GetComponent<IItems>();
    }

    private void CheckData()
    {
        if (_itemsPrefabs.Count()==0)
        {
            Debug.Log("Отсутствуют предметы для сетки предметов "+gameObject.name+" !");
        }
    }
    
    public void CheckGrid(IItem item, ISlot newParent)
    {
        if (IsHeroGrid())
        {
            Debug.Log("Герой покупает данный предмет!");
            GameManager.instance.BuyGameObjectItem(item, newParent);
        }
        else
        {
            Debug.Log("Герой продаёт данный предмет!");
            GameManager.instance.SellGameObjectItem(item, newParent);
        }
    }


    private bool IsHeroGrid()
    {
        return gameObject.CompareTag("Hero Items");
    }
    
}