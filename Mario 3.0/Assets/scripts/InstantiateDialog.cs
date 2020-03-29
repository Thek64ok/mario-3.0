using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InstantiateDialog : MonoBehaviour
{
    public TextAsset ta;
    public Dialog dialog;
  
    public int currentNode;
    public bool ShowDialogue;
   

    public GUISkin skins;
    
    public List<Answer> answers = new List<Answer>();
   
    void Start()
    {
        dialog = Dialog.Load(ta);
     
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knight")
            ShowDialogue = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Knight")
            ShowDialogue = false;
    }
    void Update()
    {
        UpdateAnswers();
    }

    void UpdateAnswers()
    {

        answers.Clear();
        for (int i = 0; i < dialog.nodes[currentNode].answers.Length; i++)
        {
            if (dialog.nodes[currentNode].answers[i].QuestName == null || dialog.nodes[currentNode].answers[i].NeedQuestValue == PlayerPrefs.GetInt(dialog.nodes[currentNode].answers[i].QuestName))
                answers.Add(dialog.nodes[currentNode].answers[i]);
        }
    }
    
    void OnGUI()
    {
        GUI.skin = skins;
        if (ShowDialogue)
        {
           
           
            
            GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height - 300, 600, 250), "");
            GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height - 280, 500, 90), dialog.nodes[currentNode].NpcText);
            for (int i = 0; i < answers.Count; i++)
            {

                if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height - 200 + 25 * i, 500, 25), answers[i].text, skins.label))
                {
                    if (answers[i].QuestValue > 0)
                    {
                        PlayerPrefs.SetInt(answers[i].QuestName, answers[i].QuestValue);
                    }
                    if (answers[i].end == "true")
                    {
                        
                        ShowDialogue = false;
                    }
                    currentNode = answers[i].nextNode;
                }
            }
        }
    }
}