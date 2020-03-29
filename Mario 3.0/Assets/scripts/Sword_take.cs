using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword_take : MonoBehaviour
{
    public Text pickUpText;
    private bool pickUpAllowed;
    public GameObject otherGame;
    public wasd take;
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
        take = otherGame.GetComponent<wasd>();
    }
    void Update()
    {
        //if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
            take.dayn = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Knight"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Knight"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }
    private void PickUp()
    {
        gameObject.SetActive(false);
    }
}
