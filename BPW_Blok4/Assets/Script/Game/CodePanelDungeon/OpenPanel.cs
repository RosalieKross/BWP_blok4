using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : Interactable
{

    [Header("Open Inventory")]
    public bool isPanelOpen;
    public GameObject CodePanel;
    //public bool playerInRange;
    // Start is called before the first frame update

    void Start()
    {
        isPanelOpen = false;
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            OpenTheCodePanel();
        }
        
    }

    public void OpenTheCodePanel()
    {
        isPanelOpen = !isPanelOpen;
        if (isPanelOpen)
        {
            CodePanel.SetActive(true);
            Time.timeScale = 0f;

        }
        else
        {
            CodePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            
            Debug.Log("playern QuestZone");

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("player left");

        }

    }

}

