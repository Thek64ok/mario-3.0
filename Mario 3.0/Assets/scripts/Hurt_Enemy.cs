using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageToGive;
    public GameObject blood;
    public Transform hitPoint;
    public GameObject damageNumber1;
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
            Instantiate(blood, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber1, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<Numbers_of_damage>().damageNumber2 = damageToGive;
        }
    }
}
