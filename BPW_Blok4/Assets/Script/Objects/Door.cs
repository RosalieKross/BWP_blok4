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
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public BoxCollider2D physicsCollider2;

    public DialogManager DM;
    public string[] dialogueLines;



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
    


    public void Open()
    {
        doorSprite.enabled = false;
        open = true;
        physicsCollider.enabled = false;
        physicsCollider2.enabled = false;
    }

    public void Close()
    {

    }
}
