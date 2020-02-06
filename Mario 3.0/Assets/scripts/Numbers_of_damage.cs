using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Numbers_of_damage : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public int damageNumber2;
    public Text displayNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayNumber.text = "" + damageNumber2;
        transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
    }
}
