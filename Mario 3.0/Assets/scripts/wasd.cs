using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasd : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 20f;
    private Rigidbody2D rb;
    private Animator anime;
    private bool moving;
    private Vector2 lastMove;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();    
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moving = false;
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            moving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
            moving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        anime.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anime.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anime.SetBool("Moving", moving);
        anime.SetFloat("LastMoveX", lastMove.x);
        anime.SetFloat("LastMoveY", lastMove.y);
    }
}
