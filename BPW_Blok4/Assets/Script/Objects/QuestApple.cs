using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestApple : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public InventoryItem AddApple;
    public bool pickedUp;
    public BoolValue isPickedUp;

    // Start is called before the first frame update
    void Start()
    {
        pickedUp = isPickedUp.RunTimeValue;
        if (pickedUp)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            SoundManager.PlayeSound("ItemPickUp");
            playerInventory.numberOfApples += 1;
            AddAppleInventory();

            pickedUp = true;
            isPickedUp.RunTimeValue = pickedUp;
            Destroy(this.gameObject);
        }
    }

    void AddAppleInventory()
    {
        if (playerInventory && AddApple)
        {
            if (playerInventory.myInventory.Contains(AddApple))
            {
                AddApple.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(AddApple);
                AddApple.numberHeld += 1;
            }
        }
    }

}