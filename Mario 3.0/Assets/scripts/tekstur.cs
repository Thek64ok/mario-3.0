
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekstur : MonoBehaviour
{   public GameObject map1;
    public GameObject map2;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            map1.SetActive(false);
            map2.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            map1.SetActive(true);
            map2.SetActive(false);
        }  
    }
}
