using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Udaru : MonoBehaviour
{

    public AudioClip footsteps;


    public void Zalupa ()
    {

        AudioSource.PlayClipAtPoint(footsteps, transform.position);
    }
}
