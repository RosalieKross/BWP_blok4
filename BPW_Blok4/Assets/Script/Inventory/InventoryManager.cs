using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryScrollViewContext;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;

    

    
    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive)
        {
            useButton.SetActive(true);

        }
        else
        {
            useButton.SetActive(false);
        }
    }

    public void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                if (playerInventory.myInventory[i].numberHeld > 0 || playerInventory.myInventory[i].itemName == "bottle")
                    {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryScrollViewContext.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryScrollViewContext.transform);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

    

    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }

    private void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryScrollViewContext.transform.childCount; i ++)
        {
            Destroy(inventoryScrollViewContext.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonPressed()
    {
        if (currentItem)
        {
            currentItem.Use();
            ClearInventorySlots();
            MakeInventorySlots();
            if(currentItem.numberHeld == 0)
            {
                SetTextAndButton("", false);
            }
            

        }
    }
}
