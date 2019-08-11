using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Chest : Interactable
{
    public InventoryItem contents;
    public PlayerInventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;
    public Signal RaiseItem;
    
    private Animator anim;
    public DialogManager DM;
    public string[] dialogueLines;
    public bool itemReceived;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RunTimeValue;
        if (isOpen)
        {
            Debug.Log("open in nieuwe scene load");
            anim.SetBool("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestAlreadyOpen();
                DM.dialogBox.SetActive(false);
                DM.BoxActive = false;
                DM.currentLine = 0;
            }

        }


    }

    public void OpenChest()
    {
        if (!DM.BoxActive)
        {
            DM.ShowDialog();
            DM.dialogLines = dialogueLines;
            playerInventory.numberOfKeys += 1;
            itemReceived = true;
            playerInventory.currentItem = contents;
            AddItemToInventory();
            RaiseItem.Raise();
            SoundManager.PlayeSound("OpenChest");
            isOpen = true;
            contextSignal.Raise();
            anim.SetBool("opened", true);
            storedOpen.RunTimeValue = isOpen;
        }

        




    }

    public void ChestAlreadyOpen()
    {
        
            DM.dialogBox.SetActive(false);
            DM.BoxActive = false;
            DM.currentLine = 0;
        // playerInventory.currentItem = null;
            RaiseItem.Raise();
            
        
    }



    void AddItemToInventory()
    {


        if (playerInventory && contents)
        {
            if (playerInventory.myInventory.Contains(contents))
            {
                contents.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(contents);
                contents.numberHeld += 1;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            playerInRange = true;
            contextSignal.Raise();
            Debug.Log("playern QuestZone");

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            contextSignal.Raise();
            playerInRange = false;
            Debug.Log("player left");

        }

    }
}
