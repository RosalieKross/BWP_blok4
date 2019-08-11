using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCreditScene : Interactable
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
                //DM.currentLine = 0;
                DM.ShowDialog();
            }
            else
            {
                DM.dialogBox.SetActive(false);
                DM.BoxActive = false;
                SceneManager.LoadScene("CreditsScene");
            }
        }
    }
}