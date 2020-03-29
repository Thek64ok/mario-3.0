using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject dragedObject;
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragedObject = gameObject;
        inventory.dragPrefab.SetActive(true);
        inventory.dragPrefab.GetComponent<CanvasGroup>().blocksRaycasts = false;
        if(dragedObject.GetComponent<CurrentItem>())
        {
            int index = dragedObject.GetComponent<CurrentItem>().index;
            inventory.dragPrefab.GetComponent<Image>().sprite = inventory.item[index].icon;
            if (inventory.item[index].countItem > 1)
            {
                inventory.dragPrefab.transform.GetChild(0).GetComponent<Text>().text = inventory.item[index].countItem.ToString();   
            }
            else
            {
                inventory.dragPrefab.transform.GetChild(0).GetComponent<Text>().text = null;
            }
            if (inventory.dragPrefab.GetComponent<Image>().sprite == null)
            {
                dragedObject = null;
                inventory.dragPrefab.SetActive(false);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Camera uiCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        inventory.dragPrefab.transform.position = uiCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragedObject = null;
        inventory.dragPrefab.SetActive(false);
        inventory.dragPrefab.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
