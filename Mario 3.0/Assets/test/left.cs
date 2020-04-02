using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left : MonoBehaviour
{
    public bool dayn;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (dayn)
          //  test.myrigidbody2D.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            dayn = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            dayn = false;
    }
}
