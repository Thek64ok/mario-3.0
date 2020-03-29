using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Inventory inventory;


    void OnDisable()
    {
        inventory.tooltipObj.SetActive(false);
    }
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();    
    }

    void Update()
    {
        Camera uiCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        inventory.tooltipObj.transform.position = uiCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)); 
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        CurrentItem currentItem = GetComponent<CurrentItem>();
        Item item = inventory.item[currentItem.index];
        if(item.id != 0)
        {
            inventory.tooltipObj.SetActive(true);
            inventory.icon.sprite = item.icon;
            inventory.itemName.text = item.nameItem;
            inventory.description.text = item.descriptionItem;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventory.tooltipObj.SetActive(false);
    }

}
