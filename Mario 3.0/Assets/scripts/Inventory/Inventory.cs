using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Inventory : MonoBehaviour
{ public Database data;
    public List<ItemInentory> items = new List<ItemInentory> ();
    public GameObject gameObjShow;
    public GameObject InventoryMainObject;
    public int maxCount;

    public Camera cam;
    public EventSystem es;
    public int currentID;
    public ItemInentory currentItem;
    public RectTransform movingObj;
    public Vector3 offset;
    public void addItem(int id, Item item, int count)
    {
        items[id].id = item.id;
        items[id].count = count;
        items[id].intemGameObj.GetComponent<Image>().sprite = item.img;
        if(count>1 && item.id!=0)
        {
            items[id].intemGameObj.GetComponentInChildren<Text>().text = count.ToString();

        }
        else
        {
            items[id].intemGameObj.GetComponentInChildren<Text>().text = "";
        }

    }
    public void addInventoryItem(int id, ItemInentory invItem )
    {
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].intemGameObj.GetComponent<Image>().sprite = data.items[invItem.id].img;
        if (invItem.count > 1 && invItem.id != 0)
        {
            items[id].intemGameObj.GetComponentInChildren<Text>().text = invItem.count.ToString();

        }
        else
        {
            items[id].intemGameObj.GetComponentInChildren<Text>().text = "";
        }

    }
    public void addGraphics()
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject;
            newItem.name = i.ToString();

            ItemInentory ii = new ItemInentory();
            ii.intemGameObj = newItem;
            RectTransform rt = newItem.GetComponent<RectTransform>();

            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);

            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(ii);
        }
    }
    public void UpdateInvetory()
    {
        for(int i=0; i<maxCount;i++)
        {
            if (items[i].id != 0 && items[i].count > 1)
            {
                items[i].intemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].intemGameObj.GetComponentInChildren<Text>().text = "";
            }
            items[i].intemGameObj.GetComponentInChildren<Image>().sprite = data.items[items[i].id].img;
        }

    }
    public void SelectObject()
    {
        if(currentID==-1)
        {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentItem = CopyInventoryItem(items[currentID]);
            movingObj.gameObject.SetActive(true);
            movingObj.GetComponent<Image>().sprite = data.items[currentItem.id].img;
            addItem(currentID,data.items[0],0);
        }
        else 
        {
            addInventoryItem(currentID, items[int.Parse(es.currentSelectedGameObject.name)]);
            addInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
            currentID = -1;
            movingObj.gameObject.SetActive(false);



        }

    }
    public void MoveObj()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObj.position = cam.ScreenToWorldPoint(pos);
        
    }
    public ItemInentory CopyInventoryItem(ItemInentory old)
    {
        ItemInentory New = new ItemInentory();
        New.id = old.id;
        New.intemGameObj = old.intemGameObj;
        New.count = old.count;
        return New;
    }
}
[System.Serializable]
public class ItemInentory
{
    public int id;
    public GameObject intemGameObj;
    public int count;
}
