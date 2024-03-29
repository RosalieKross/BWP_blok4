﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Powerup
{
    public PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;

    // Start is called before the first frame update
    void Start()
    {
        powerupSignal.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {

            AddItemToInventory();
            playerInventory.coins += 1; 
            powerupSignal.Raise();
            SoundManager.PlayeSound("coinPickup");
            Destroy(this.gameObject);
        }
    }

    void AddItemToInventory()
    {


        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }

}
