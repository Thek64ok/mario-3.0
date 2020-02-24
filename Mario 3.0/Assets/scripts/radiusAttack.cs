using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radiusAttack : MonoBehaviour
{
    public GameObject knight;
    public GameObject[] positions;
    private wasd knightFromScript;
    public Image imageCoolDown;
    public float coolDown;
    private float timeForCoolDown;
    public bool coolDownOver;
    private bool trap;
    void Start()
    {
        knightFromScript = knight.gameObject.GetComponent<wasd>();
        coolDownOver = true;
        positions = GameObject.FindGameObjectsWithTag("Enemy");
        timeForCoolDown = coolDown;
        
    }

    // Update is called once per frame
    void Update()
    {
        positions = GameObject.FindGameObjectsWithTag("Enemy");
        if (knightFromScript.dayn == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (coolDownOver)
                {
                    for (int i = 0; i < positions.Length; i++)
                    {
                        if (trap)
                        {
                            positions[i].transform.position = new Vector2(positions[i].transform.position.x + Random.Range(-1f, 1f) / 0.5f, positions[i].transform.position.y + Random.Range(-1f, 1f) / 0.5f);
                            coolDownOver = false;
                        }
                        else
                            coolDownOver = false;
                    }
                }
            }
            if (!coolDownOver)
            {
                coolDown -= Time.deltaTime;
                imageCoolDown.fillAmount += 1 / timeForCoolDown * Time.deltaTime;
                if (imageCoolDown.fillAmount >= 1)
                    imageCoolDown.fillAmount = 0;
            }
            if (coolDown < 0)
            {
                coolDownOver = true;
                coolDown = 5f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
            trap = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
            trap = false;
    }
}
