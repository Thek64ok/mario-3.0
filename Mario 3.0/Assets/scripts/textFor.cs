using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textFor : MonoBehaviour
{
    public bool inside;
    public GameObject dialog;
    void Start()
    {
        inside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inside)
        {
            if (Input.GetKeyDown(KeyCode.E))
                dialog.SetActive(true);
        }
        else
            dialog.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knight")
            inside = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knight")
            inside = false;
    }
}
