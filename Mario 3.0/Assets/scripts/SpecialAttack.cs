using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAttack : MonoBehaviour
{
    public GameObject knight;
    private wasd knightFromSkript;
    public float coolDown;
    public bool coolDownOver;
    public Image imageCoolDown;
    private float coolDownForSkill;
    private Transform target;
    public float timeToCast = 1f;
    void Start()
    {
        knightFromSkript = knight.gameObject.GetComponent<wasd>();
        coolDownOver = true;
        coolDownForSkill = coolDown;
        target = GameObject.FindGameObjectWithTag("a").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knightFromSkript.dayn == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (coolDownOver)
                {
                    timeToCast = 1f;
                    if (knightFromSkript.lastMove.x > 0.5f)
                    {
                        if (Vector2.Distance(knight.transform.position, target.transform.position) < 2.5f)
                        {
                            target.transform.position = new Vector2(target.transform.position.x + 0.5f, target.transform.position.y);
                            knightFromSkript.anime.SetBool("Skill1", true);
                        }
                        else
                        {
                            knightFromSkript.anime.SetBool("Skill1", true);
                        }
                    }
                    else
                    {
                        if (knightFromSkript.lastMove.x < 0.5f)
                        {
                            if (Vector2.Distance(knight.transform.position, target.transform.position) < 2.5f)
                            {
                                target.transform.position = new Vector2(target.transform.position.x - 0.5f, target.transform.position.y);
                                knightFromSkript.anime.SetBool("Skill1", true);
                            }
                            else
                            {
                                knightFromSkript.anime.SetBool("Skill1", true);
                            }
                        }
                        else
                        {
                            if (knightFromSkript.lastMove.y > 0.5f)
                            {
                                if (Vector2.Distance(knight.transform.position, target.transform.position) < 2.5f)
                                {
                                    target.transform.position = new Vector2(target.transform.position.x, target.transform.position.y + 0.5f);
                                    knightFromSkript.anime.SetBool("Skill1", true);
                                }
                                else
                                {
                                    knightFromSkript.anime.SetBool("Skill1", true);
                                }
                            }
                            else
                            {
                                if (Vector2.Distance(knight.transform.position, target.transform.position) < 2.5f)
                                {
                                    target.transform.position = new Vector2(target.transform.position.x, target.transform.position.y - 0.5f);
                                    knightFromSkript.anime.SetBool("Skill1", true);
                                }
                                else
                                {
                                    knightFromSkript.anime.SetBool("Skill1", true);
                                }
                            }
                        }
                    }
                    coolDownOver = false;
                }
            }
            if (coolDownOver == false)
            {
                timeToCast -= Time.deltaTime;
                coolDown -= Time.deltaTime;
                imageCoolDown.fillAmount += 1 / coolDownForSkill * Time.deltaTime;
                if (imageCoolDown.fillAmount >= 1)
                    imageCoolDown.fillAmount = 0;
            }
            if (coolDown < 0 && timeToCast < 0)
            {
                coolDownOver = true;
                coolDown = 5f;
            }
            if (timeToCast < 0)
            {
                knightFromSkript.anime.SetBool("Skill1", false);
            }
        }
    }
    public bool GetCoolDownOver()
    {
        return coolDownOver;
    }
}
