using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{

    private QuestManager QM;
    public int questNumber;

    public bool startQuest;
    public bool endQuest;
    public bool playerInRange;
    public DialogManager DM;


    // Start is called before the first frame update
    void Start()
    {
        QM = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
           // playerInRange = true;
           // Debug.Log("player startedQuest");
        {
            
                if (!QM.completedQuests[questNumber])
                {
                    if (startQuest && !QM.quests[questNumber].gameObject.activeSelf)
                    {
                        QM.quests[questNumber].gameObject.SetActive(true);
                        QM.quests[questNumber].StartQuest();
                        
                    }

                    if (endQuest && QM.quests[questNumber].gameObject.activeSelf)
                    {
                        QM.quests[questNumber].EndQuest();
                    }

                }
            }
        
    }

    

}
