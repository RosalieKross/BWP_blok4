using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{

    private QuestManager QM;
    public int questNumber;

    public bool startQuest;
    public bool endQuest;
    public bool playerInRange;
    public DialogManager DM;
    public Vector3 playerChange;


    public Signal quest;

    



    // Start is called before the first frame update
    void Start()
    {
        QM = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {

            StartTheQuest();

                if (endQuest && QM.quests[questNumber].gameObject.activeSelf)
                    {
                        QM.quests[questNumber].EndQuest();
                        Debug.Log("Quest Ended");
                    }
      
    }



    public void StartTheQuest()
    {

        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!QM.completedQuests[questNumber])
            {


                if (startQuest && !QM.quests[questNumber].gameObject.activeSelf)
                {
                    QM.quests[questNumber].gameObject.SetActive(true);
                    QM.quests[questNumber].StartQuest();
                    transform.position += playerChange;

                }
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("Player"))
        {
            playerInRange = true;
            quest.Raise();
            Debug.Log("playern QuestZone");
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            quest.Raise();
            playerInRange = false;
            Debug.Log("player left");
        }

    }

}