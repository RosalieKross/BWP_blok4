using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEnemyTooth : Powerup
{
    public PlayerInventory playerInventory;
    public InventoryItem AddTooth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.numberOfEnemyTooth += 1;
            SoundManager.PlayeSound("ItemPickUp");
            AddToothInventory();

            Destroy(this.gameObject);
        }
    }

    void AddToothInventory()
    {
        if (playerInventory && AddTooth)
        {
            if (playerInventory.myInventory.Contains(AddTooth))
            {
                AddTooth.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(AddTooth);
                AddTooth.numberHeld += 1;
            }
        }
    }
}
