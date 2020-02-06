using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasd : MonoBehaviour
{
    public float speed ;
    private float currentMoveSpeed;
    private Rigidbody2D rb;
    private Animator anime;
    private bool moving;
    private Vector2 lastMove;
    private Rigidbody2D myrigidbody2D;
    public int dayn;
    public GameObject Readl_Sword;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    void Start()
    {   
        anime = GetComponent<Animator>();
        Readl_Sword.SetActive(false);
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))//Sprint
        {
            speed = 1.5f;
        }
        else
            speed = 1;
    }
    void Update()
    {
        moving = false;
        Sprint();
        if (!attacking)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                // transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
                myrigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myrigidbody2D.velocity.y);
                moving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
                myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                moving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myrigidbody2D.velocity = new Vector2(0f, myrigidbody2D.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, 0f);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myrigidbody2D.velocity = Vector2.zero;
                anime.SetBool("Attack", true);
            }
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = speed / 1.5f;
            }
            else
            {
                currentMoveSpeed = speed;
            }
        }
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime * 5;
        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anime.SetBool("Attack", false);
        }
        anime.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anime.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anime.SetBool("Moving", moving);
        anime.SetFloat("LastMoveX", lastMove.x);
        anime.SetFloat("LastMoveY", lastMove.y);
        if (dayn == 1)
        {
            anime.SetTrigger("taking");
            Readl_Sword.SetActive(true);
        }
    }
}
