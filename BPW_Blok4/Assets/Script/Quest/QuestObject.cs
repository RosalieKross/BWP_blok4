using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{

    public int questNumber;
    public QuestManager questMan;

    public string[] StartText;
    public string[] EndText;


    public bool isItemQuest;
    public string targetItem;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isItemQuest)
        {
            if(questMan.isItemCollected == targetItem)
            {
                questMan.isItemCollected = null;

                EndQuest();
            }
        }  
    }

    public void StartQuest()
    {
        questMan.questText = StartText;
        questMan.ShowQuestText();
    }

    public void EndQuest()
    {
        questMan.questText = EndText;
        questMan.ShowQuestText();
        questMan.completedQuests[questNumber] = true;
        gameObject.SetActive(false);
    }
}
