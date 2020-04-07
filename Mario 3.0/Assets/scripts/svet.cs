using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class svet : MonoBehaviour
{
    public bool check;
    public Text text;
    public GameObject map1;
    public GameObject map2;
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            text.enabled = check;
            if (Input.GetKeyDown(KeyCode.E))
            {
                map1.SetActive(false);
                map2.SetActive(true);

            }
          
        }
        else
          
            text.enabled = check;
         
    }
  public void zalupa()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            check = true;
            text.enabled = check;

        }
            
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          
            check = false;
            text.enabled = check;

        }
    }
}
