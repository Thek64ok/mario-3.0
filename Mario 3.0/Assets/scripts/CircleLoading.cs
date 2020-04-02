using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CircleLoading : MonoBehaviour
{
    //public int loadSceneID;
    public Image loadCircle;
    private int LoadDone;
    void Start()
    {
        /*
        if (!MenuControls.check1)
        {
            LoadDone = 0;
            PlayerPrefs.SetInt("check", LoadDone);
        }
        else
        {
            LoadDone = 1;
            PlayerPrefs.SetInt("check", LoadDone);
        }
        */
        LoadDone = 1;
        PlayerPrefs.SetInt("check", LoadDone);
        StartCoroutine(AsyncLoad());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(MenuControls.IDScen);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadCircle.fillAmount = progress;
            yield return null;
        }
    }
}
