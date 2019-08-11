using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    FetchQuest,
    KillQuest,
    TalkQuest,
    CoinQuest

}

public class QuestObject : Powerup
{
    public int questNumber;
    public QuestManager questMan;
    public QuestGiver QG;

    public QuestType thisQuestType;

    public string[] StartText;
    public string[] EndText;

    //public bool playerInRange;

    public PlayerInventory playerInventory;
    public InventoryItem thisItem;
    public InventoryItem AddMasterKey;
    public InventoryItem removeTooht;
    public InventoryItem AddCoin;
    public InventoryItem removeApple;
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
            if (thisQuestType == QuestType.FetchQuest)
            {
                if (playerInventory.numberOfApples >= 3)
                {
                    Debug.Log("Items gegeven");
                    playerInventory.numberOfApples -= 3;
                    RemoveAppleFromInventory();
                    playerInventory.coins += 3;
                    AddCoinToInventory();
                    EndQuest();
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && QG.playerInRange) //fetch quest.. Bring apple to villager
        {
            if (thisQuestType == QuestType.CoinQuest)
            {
                if (playerInventory.coins >= 10)
                {
                    Debug.Log("Items gegeven");
                    playerInventory.coins -= 10;
                    playerInventory.numberOfMasterKey += 1;
                    AddMasterKeyToInventory();
                    RemoveCoinFromInventory();
                    EndQuest();
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && QG.playerInRange) //fetch quest.. Bring apple to villager
        {
            if (thisQuestType == QuestType.KillQuest)
            {
                if (playerInventory.numberOfEnemyTooth >= 3)
                {
                    Debug.Log("Items gegeven");
                    playerInventory.numberOfEnemyTooth -= 3;
                    RemoveToothFromInventory();
                    playerInventory.coins += 3;
                    AddCoinToInventory();
                    EndQuest();
                }

            }
        }
    }


    void RemoveAppleFromInventory()
    {

        if (playerInventory && removeApple)
        {
            if (playerInventory.myInventory.Contains(removeApple))
            {
                removeApple.numberHeld -= 3;
            }
            else
            {
                playerInventory.myInventory.Add(removeApple);
                removeApple.numberHeld -= 3;
            }
        }
    }


    void RemoveToothFromInventory()
    {

        if (playerInventory && removeTooht)
        {
            if (playerInventory.myInventory.Contains(removeTooht))
            {
                removeTooht.numberHeld -= 3;
            }
            else
            {
                playerInventory.myInventory.Add(removeTooht);
                removeTooht.numberHeld -= 3;
            }
        }
    }

    void AddMasterKeyToInventory()
    {
        if (playerInventory && AddMasterKey)
        {
            if (playerInventory.myInventory.Contains(AddMasterKey))
            {
                AddMasterKey.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(AddMasterKey);
                AddMasterKey.numberHeld += 1;
            }
        }
    }


    void RemoveCoinFromInventory()
    {

        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld -= 3;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld -= 3;
            }
        }
    }

    void AddCoinToInventory()
    {

        if (playerInventory && AddCoin)
        {
            if (playerInventory.myInventory.Contains(AddCoin))
            {
                AddCoin.numberHeld += 3;
            }
            else
            {
                playerInventory.myInventory.Add(AddCoin);
                AddCoin.numberHeld += 3;
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
        
        powerupSignal.Raise();
        questMan.questText = EndText;
        questMan.ShowQuestText();
        questMan.completedQuests[questNumber] = true;
        gameObject.SetActive(false);

    }
}