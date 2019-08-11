using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    masterkey,
    enemy,
    button
}


public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public BoolValue isOpened;
    public PlayerInventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public BoxCollider2D physicsCollider2;

    [SerializeField] private InventoryItem thisItem;

    public DialogManager DM;
    public string[] dialogueLines;


     void Start()
    {

        open = isOpened.RunTimeValue;
        if (open)
        {
            doorSprite.enabled = false;
            physicsCollider.enabled = false;
            physicsCollider2.enabled = false;
        }
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && !open)
        {
            if (!DM.BoxActive)
            {
                DM.dialogLines = dialogueLines;
                //DM.currentLine = 0;
                DM.ShowDialog();
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (playerInRange && thisDoorType == DoorType.key)
            {
                if (playerInventory.numberOfKeys > 0)
                {
                    //remove player key
                    DM.dialogBox.SetActive(false);
                    DM.BoxActive = false;
                    playerInventory.numberOfKeys--;
                    RemoveFromInventory();
                    Open();
                }
            }

           
            if (playerInRange && thisDoorType == DoorType.masterkey)
                {
                    if (playerInventory.numberOfMasterKey > 0)
                    {
                    //remove player key
                    DM.dialogBox.SetActive(false);
                    DM.BoxActive = false;
                    playerInventory.numberOfMasterKey--;
                        Open();
                    }
                }
            }
        }

    void RemoveFromInventory()
    {

        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld -= 1;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld -= 1;
            }
        }
    }

    public void Open()
    {
        SoundManager.PlayeSound("UnlockDoor");
        doorSprite.enabled = false;
        open = true;
        isOpened.RunTimeValue = open;
        physicsCollider.enabled = false;
        physicsCollider2.enabled = false;
    }

    public void Close()
    {

    }
}
