using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DialogHolder : MonoBehaviour
{

    public DialogManager DM;
    public bool playerInRange;
    public string[] dialogueLines;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("player in zone");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!DM.BoxActive)
                {
                    DM.dialogLines = dialogueLines;
                    DM.currentLine = 0;
                    DM.ShowDialog();
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("player left");
            DM.dialogBox.SetActive(false);
            DM.BoxActive = false;
            DM.currentLine = 0;
        }
    }



}


