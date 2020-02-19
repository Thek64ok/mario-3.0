using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public GameObject knight;
    private wasd damage;
    private bool check;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        damage = knight.GetComponent<wasd>();
    }

    // Update is called once per frame
    void Update()
    {
        if (check == true)
        {
            if (damage.lastMove.x > 0)
                rigidbody.AddForce(Vector2.right * 2f + 4f * rigidbody.velocity.normalized, ForceMode2D.Impulse);
            else
            {
                if (damage.lastMove.x < 0)
                    rigidbody.AddForce(Vector2.left * 2f + 4f * rigidbody.velocity.normalized, ForceMode2D.Impulse);
                else
                {
                    if (damage.lastMove.y > 0)
                        rigidbody.AddForce(Vector2.up * 2f + 4f * rigidbody.velocity.normalized, ForceMode2D.Impulse);
                    else
                        rigidbody.AddForce(Vector2.down * 2f + 4f * rigidbody.velocity.normalized, ForceMode2D.Impulse);
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damage.attacking == true)
        {
            if (collision.gameObject.tag.Equals("Real_Sword"))
            {
                check = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        check = false;
    }
}
