using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointDown : MonoBehaviour
{
    // Start is called before the first frame update
    public bool down;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
