using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointUp : MonoBehaviour
{
    // Start is called before the first frame update
    public bool up;
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
            up = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            up = false;
    }
}
