using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool dolboeb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dolboeb = true;
            if (PlayerPrefs.GetInt("Quest1") == 1)
            {
                PlayerPrefs.SetInt("Quest1", 2);
            }
        }
    }
}
