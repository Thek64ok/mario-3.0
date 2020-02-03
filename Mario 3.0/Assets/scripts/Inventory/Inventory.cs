using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Inventory : MonoBehaviour
{
    public List<ItemInentory> items = new List<ItemInentory> ();
    public GameObject gameObjShow;
    public GameObject InventoryMainObject;
    public int maxCount;
    public void addGraphics()
    {
        for(int i=0;i< maxCount;i++)
        {
            GameObject newItem = Instantiate(gameObjShow,InventoryMainObject.transform) as GameObject;
            newItem.name = i.ToString();

            ItemInentory ii = new ItemInentory();
            ii.intemGameObj = newItem;
            RectTransform rt = newItem.GetComponent<RectTransform>();

            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
           
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
            Button tempButton = newItem.GetComponent<Button>();
            items.Add(ii);
        }
    }
}
[System.Serializable]
public class ItemInentory
{
    public int id;
    public GameObject intemGameObj;
    public int count;
}
