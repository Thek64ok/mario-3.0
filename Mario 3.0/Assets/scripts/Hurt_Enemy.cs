using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageToGive;
    public GameObject blood;
    public Transform hitPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthMeneger>().HurtEnemy(damageToGive);
            // Destroy(other.gameObject);
            Instantiate(blood, hitPoint.position, hitPoint.rotation);
        }
    }
}
