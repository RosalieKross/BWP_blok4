using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : Interactable
{


    
    public DialogManager DM;
    public string[] dialogueLines;
    



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!DM.BoxActive)
            {
                DM.dialogLines = dialogueLines;
                DM.currentLine = 0;
                DM.ShowDialog();
            }
        }
    }

    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            contextSignal.Raise();
            playerInRange = false;
            Debug.Log("player left");
            DM.dialogBox.SetActive(false);
            DM.BoxActive = false;
            DM.currentLine = 0;
        }

    }
}
