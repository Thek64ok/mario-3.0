using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointLeft : MonoBehaviour
{
    public bool left;
    private wasd knight;
    // Start is called before the first frame update
    void Start()
    {
        knight = FindObjectOfType<wasd>();
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
            knight.myrigidbody2D.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            left = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            left = false;
    }
}
