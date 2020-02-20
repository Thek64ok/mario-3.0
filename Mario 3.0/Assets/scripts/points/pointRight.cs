using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointRight : MonoBehaviour
{
    // Start is called before the first frame update
    public bool right;
    public GameObject knight;
    private wasd dayn;
    void Start()
    {
        dayn = knight.GetComponent<wasd>();
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
            dayn.myrigidbody2D.AddForce(Vector2.left * 5f, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            right = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            right = false;
    }
}
