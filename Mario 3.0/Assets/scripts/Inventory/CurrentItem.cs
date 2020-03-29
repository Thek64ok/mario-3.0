using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CurrentItem : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    [HideInInspector]
    public int index;
    GameObject inventoryObj;
    Inventory inventory;
    void Start()
    {
        inventoryObj = GameObject.FindGameObjectWithTag("InventoryManager");
        inventory = inventoryObj.GetComponent<Inventory>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (inventory.item[index].customEvent != null)
            {
                inventory.item[index].customEvent.Invoke();
            }
            if(inventory.item[index].isRemovable)
            {
                Remove();        
            }
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(inventory.item[index].isDroped)
            {
                Drop();
                Remove();
            }
        }
    }
    void Remove()
    {
        if (inventory.item[index].id != 0)
            {
                if (inventory.item[index].countItem > 1)
                {
                    inventory.item[index].countItem--;    
                }
                else
                {
                    inventory.item[index] = new Item();
                }
                inventory.DisplayItems();
            }
    }
    void Drop()
    {
        if (inventory.item[index].id != 0)
        {
            for (int i = 0; i < inventory.database.transform.childCount; i++)
            {
                Item item = inventory.database.transform.GetChild(i).GetComponent<Item>();
                if(item)
                {
                    if(inventory.item[index].id == item.id)
                    {
                        GameObject dropedObj = Instantiate(item.gameObject , inventory.itemPlayBase.transform);
                        Debug.Log(dropedObj.tag);
                        dropedObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
                    }
                }
            }
        }
    }
    public int FindItemId(int id)
    { 
        for (int i = 0; i < inventory.item.Count; i++)
        {
            if(inventory.item[i].id == id)
            {
                return i;
            }
        }
        return -1;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragedObject = Drag.dragedObject;
        if (dragedObject == null)
        {
            return;
        }
        CurrentItem currentdragedItem = dragedObject.GetComponent<CurrentItem>();
        if (currentdragedItem)
        {
            Item CurrentItem = inventory.item[GetComponent<CurrentItem>().index];
            inventory.item[GetComponent<CurrentItem>().index] = inventory.item[currentdragedItem.index];
            inventory.item[currentdragedItem.index] = CurrentItem;
            inventory.DisplayItems();
        }
    }
}
