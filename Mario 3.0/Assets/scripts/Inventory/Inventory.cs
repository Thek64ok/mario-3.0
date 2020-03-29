using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{
    [HideInInspector]
    public List<Item> item;
    public GameObject database;
    public GameObject itemPlayBase;
    public GameObject cellContainer;
    public KeyCode showInventory;
    public KeyCode takeButton;
    public GameObject dragPrefab;
    public GameObject player;
    [Header("Massage")]
    public GameObject massageManager;
    public GameObject massage;
    [Header("Tooltip")]
    public GameObject tooltipObj;
    public Image icon;
    public Text itemName;
    public Text description;
    void Start()
    {
        tooltipObj.SetActive(false);
        item = new List<Item>();

        cellContainer.SetActive(false);
        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            cellContainer.transform.GetChild(i).GetComponent<CurrentItem>().index = i;
        }

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            item.Add(new Item());
        }
    }

    void Update()
    {
        ToggleInventory();
        
        if(Input.GetKeyDown(takeButton))
        {   
            Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero);
        
            if(Physics2D.Raycast(CurMousePos, Vector2.zero))
            {
                if(rayHit.collider.GetComponent<Item>())
                {
                    var heading = rayHit.transform.position - player.transform.position;
                    if(heading.x <= 0.5f && heading.x >= -0.5f && heading.y <= 0.5f && heading.y >= -0.5f)
                    {
                        Item currentItem = rayHit.collider.GetComponent<Item>();
                        Massage(currentItem);
                        AddItem(rayHit.collider.GetComponent<Item>());
                    }
                }
            }
            
        }    
    }
    void Massage(Item currentItem)
    {
        GameObject msgObj = Instantiate(massage, massageManager.transform);
        Image msgImg = msgObj.transform.GetChild(0).GetComponent<Image>();
        msgImg.sprite = currentItem.icon;

        Text msgTxt = msgObj.transform.GetChild(1).GetComponent<Text>();
        msgTxt.text = currentItem.nameItem;
    }
    void AddItem(Item currentItem)
    {
        if (currentItem.isStackable)
        {
            AddStackableItem(currentItem);
        }
        else
        {
            AddUnstackableItem(currentItem);
        }
    }
    void AddUnstackableItem(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if(item[i].id == 0)
            {
                item[i] = currentItem;
                item[i].countItem = 1;
                DisplayItems();
                Destroy(currentItem.gameObject);
                return;
            }
        }
    }
    void AddStackableItem(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if(item[i].id == currentItem.id)
            {
                item[i].countItem++;
                DisplayItems();
                Destroy(currentItem.gameObject);
                return;
            }
        }
        AddUnstackableItem(currentItem);
    }
    void ToggleInventory()
    {
        if(Input.GetKeyDown(showInventory))
        {
            if (cellContainer.activeSelf)
            {
                cellContainer.SetActive(false);
                //Time.timeScale = 1;
            }
            else
            {
                cellContainer.SetActive(true);
                //Time.timeScale = 0;
            }
        }
    }
    public void DisplayItems()
    {
        for (int i = 0; i < item.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Transform count = icon.GetChild(0);

            Image img = icon.GetComponent<Image>();
            Text txt = count.GetComponent<Text>();
            if (item[i].id != 0)
            {
                img.enabled = true;
                img.sprite = item[i].icon;
                if (item[i].countItem > 1)
                {
                    txt.text = item[i].countItem.ToString();   
                }
                else
                {
                    txt.text = null;
                }
            }
            else
            {
                img.enabled = false;
                img.sprite = null;
                txt.text = null;
            }
        }
    }
}
