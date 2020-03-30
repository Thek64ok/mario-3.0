using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointRight : MonoBehaviour
{
    public bool right;
    private wasd knight;
    void Start()
    {
        knight = FindObjectOfType<wasd>();
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
            knight.myrigidbody2D.AddForce(Vector2.left * 20f, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            right = true;
            Debug.Log("я справа");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            right = false;
            Debug.Log("я не справа");
        }
    }
}
