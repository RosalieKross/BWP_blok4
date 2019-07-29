using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool playerInRange;
    public Signal contextSignal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            contextSignal.Raise();
            Debug.Log("playern QuestZone");

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            contextSignal.Raise();
            playerInRange = false;
            Debug.Log("player left");
            //DM.dialogBox.SetActive(false);
            //DM.BoxActive = false;
            //DM.currentLine = 0;
        }

    }
}
