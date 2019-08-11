using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLetter : Powerup
{
    public PlayerInventory playerInventory;
    public InventoryItem AddLetter;

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
            AddLetterInventory();

            Destroy(this.gameObject);
        }
    }

    void AddLetterInventory()
    {
        if (playerInventory && AddLetter)
        {
            if (playerInventory.myInventory.Contains(AddLetter))
            {
                AddLetter.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(AddLetter);
                AddLetter.numberHeld += 1;
            }
        }
    }
}