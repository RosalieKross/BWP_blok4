using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{

    public int questNumber;
    public QuestManager questMan;

    public string StartText;
    public string EndText;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuest()
    {
        questMan.QuestText(StartText);
    }

    public void EndQuest()
    {
        questMan.QuestText(EndText);
        questMan.completedQuests[questNumber] = true;
        gameObject.SetActive(false);
    }
}
