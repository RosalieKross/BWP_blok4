using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum questtype
{
    FetchQuest,
    KillQuest,
    TalkQuest,
    CoinQuest

}

public class EndQuest : Powerup
{
    public int questNumber;
    public QuestManager questMan;
    public QuestGiver QG;

    public QuestType thisQuestType;

    public string[] StartText;
    public string[] EndText;

    //public bool playerInRange;

    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        powerupSignal.Raise();
    }

    // Update is called once per frame
    void Update()
    {

      if (Input.GetKeyDown(KeyCode.Space) && QG.playerInRange) //fetch quest.. Bring apple to villager
        {
            if (thisQuestType == QuestType.CoinQuest)
            {
                if (playerInventory.coins >= 3)
                {
                    Debug.Log("Items gegeven");
                    playerInventory.coins -= 3;
                    EndTheQuest();
                }

            }
        }
    }


    public void StartQuest()
    {
        questMan.questText = StartText;
        questMan.ShowQuestText();

    }

    public void EndTheQuest()
    {
        playerInventory.coins += 1;
        powerupSignal.Raise();
        questMan.questText = EndText;
        questMan.ShowQuestText();
        questMan.completedQuests[questNumber] = true;
        gameObject.SetActive(false);

    }
}