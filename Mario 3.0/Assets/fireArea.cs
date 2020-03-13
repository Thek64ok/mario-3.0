using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireArea : MonoBehaviour
{
    public bool check;
    public Text text;
    public GameObject menu;
    public GameObject Tree;
    void Start()
    {
        text.enabled = false;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            text.enabled = check;
            if (Input.GetKeyDown(KeyCode.E))
            {
                menu.SetActive(true);
                Tree.SetActive(false);
                check = false;  
                Time.timeScale = 0.000000001f;
                
                Debug.Log("Чел садится 2 секунды");
            }
        }
        else
            text.enabled = check;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knight")
            check = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knight")
            check = false;
    }
}
