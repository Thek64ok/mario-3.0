using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMassage : MonoBehaviour
{
    public float time;
    void Update()
    {
        Destroy(gameObject, time);
    }
}
