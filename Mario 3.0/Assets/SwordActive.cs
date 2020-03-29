using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordActive : MonoBehaviour
{
    public void switchSword(GameObject sword)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
