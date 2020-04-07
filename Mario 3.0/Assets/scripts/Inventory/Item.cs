using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string nameItem;
    public int id;
    [HideInInspector]
    public int countItem;
    public bool isRemovable;//расходуемый
    public bool isDroped;//можно дропнуть
    public bool isStackable;
    [Multiline]
    public string descriptionItem;
    public Sprite icon;
    public UnityEvent customEvent;
}
