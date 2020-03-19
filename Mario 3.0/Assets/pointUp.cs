using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointUp : MonoBehaviour
{
    // Start is called before the first frame update
    public bool up;
    private wasd knight;
    void Start()
    {
        knight = FindObjectOfType<wasd>();
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
            knight.myrigidbody2D.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            up = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            up = false;
    }
}
