using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myrigidbody2D;
    private right rr;
    private left ll;
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        rr = FindObjectOfType<right>();
        ll = FindObjectOfType<left>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            myrigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, myrigidbody2D.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, Input.GetAxisRaw("Vertical") * speed);
        }
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myrigidbody2D.velocity = new Vector2(0f, myrigidbody2D.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, 0f);
        }
        if (rr.dayn)
            myrigidbody2D.AddForce(Vector2.left * 20f, ForceMode2D.Impulse);
        if (ll.dayn)
            myrigidbody2D.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
    }
}
