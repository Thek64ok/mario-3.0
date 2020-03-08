using UnityEngine;
using System.Collections;

public class MissionObject : MonoBehaviour

{
    private MissionPlayer MP; 

    void Start()
    {
        MP = GameObject.FindGameObjectWithTag("sphere").GetComponent<MissionPlayer>();
    }
    void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (MP.ObjectTag == gameObject.tag) 
            {
                MP.MissionObjects = true;
                Destroy(gameObject); 
            }
        }
    }

}