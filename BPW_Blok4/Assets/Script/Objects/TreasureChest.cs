using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item contents;
    public bool isOpen;
    public Signal RaiseItem;
    //public GameObject dialogBox;
    public DialogManager DM;
    public Inventory playerInventory;
    private Animator anim;

    //public Text dialogText;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
                ChestisAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        DM.dialogBox.SetActive(true); 
        DM.dialogLines = contents.itemDescription;
        DM.currentLine = 0;
        DM.ShowDialog();

        playerInventory.AddItem(contents);

        playerInventory.currentItem = contents;

        RaiseItem.Raise();

        contextSignal.Raise();

        isOpen = true;
    }


    public void ChestisAlreadyOpen()
    {
        
            //set dialogBox uit 
            DM.dialogBox.SetActive(false);
            

            RaiseItem.Raise();
            
        
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