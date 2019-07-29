﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    public int questNumber;
    private QuestManager QM;
    public string itemName;

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
        {
            if(!QM.completedQuests[questNumber] && QM.quests[questNumber].gameObject.activeSelf)
            {
                QM.isItemCollected = itemName;
                gameObject.SetActive(false);

            }
        }
    }
}
