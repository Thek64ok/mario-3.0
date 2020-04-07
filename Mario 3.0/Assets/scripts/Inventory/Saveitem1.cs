using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Saveitem1
{
    public int id;
    [HideInInspector]
    public int countItem;

    public Saveitem1(int id, int countItem)
        {

            this.id = id;
            this.countItem = countItem;
            
        }
}
