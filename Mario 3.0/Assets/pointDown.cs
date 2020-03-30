using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointDown : MonoBehaviour
{
    // Start is called before the first frame update
    public bool down;
    //private wasd knight;
    void Start()
    {
      //  knight = FindObjectOfType<wasd>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (down)
          //  knight.myrigidbody2D.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            down = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            down = false;
    }
}
