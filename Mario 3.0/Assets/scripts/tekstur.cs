
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekstur : MonoBehaviour
{   public GameObject map1;
    public GameObject map2;
    public bool tekkstu;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knight")
            map1.SetActive(false);
            map2.SetActive(true);
        tekkstu = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knight")
            map2.SetActive(false);
            map1.SetActive(true);
            tekkstu = false;
    }

    // Update is called once per frame
    void Update()
    {
        map2.SetActive(false);
        map1.SetActive(true);
    }
}
