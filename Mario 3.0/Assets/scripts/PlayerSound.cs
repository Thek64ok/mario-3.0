using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    
    public AudioClip footsteps;

   
    public void FootStepsAudio()
    {
        
        AudioSource.PlayClipAtPoint(footsteps, transform.position);
    }
}
