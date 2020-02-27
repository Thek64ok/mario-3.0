using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataBase : MonoBehaviour
{
    public static Database instance = null;
    int sceneIndex; 
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
