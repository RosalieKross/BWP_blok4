using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    [Header("Open Inventory")]
    public bool isInventoryOpen;
    public GameObject InventoryPanel;
    // Start is called before the first frame update
    void Start()
    {
        isInventoryOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("OpenInventory"))
        {
            OpenTheInventory();
        }
    }

    public void OpenTheInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        if (isInventoryOpen)
        {
            InventoryPanel.SetActive(true);
            Time.timeScale = 0f;
            SoundManager.PlayeSound("OpenPanel");
        }
        else
        {
            InventoryPanel.SetActive(false);
            Time.timeScale = 1f;
            SoundManager.PlayeSound("OpenPanel");
        }
    }
}
