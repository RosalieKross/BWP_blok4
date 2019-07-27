using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public QuestObject[] quests;
    public bool[] completedQuests;


    public SignScript dialogManager; //dialog bubble voor quest tekst

    // Start is called before the first frame update
    void Start()
    {
        completedQuests = new bool[quests.Length]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuestText(string questText)
    {

    }
}
