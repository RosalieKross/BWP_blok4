using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Player Inventory")]

public class PlayerInventory : ScriptableObject
{

    public List<InventoryItem> myInventory = new List<InventoryItem>();
    public InventoryItem currentItem;
    public int numberOfKeys;
    public int numberOfMasterKey;
    public int numberOfApples;
    public int coins;
    public int numberOfEnemyTooth;

    public void AddItem(InventoryItem itemToAdd)
    {
        //is het een key
        if (itemToAdd.isKey)
        {
            numberOfKeys++;
        }
        if (itemToAdd.isCoin)
        {
            coins++;
        }
        if (itemToAdd.isMasterKey)
        {
            numberOfMasterKey++;
        }
        if (itemToAdd.isApple)
        {
            numberOfApples++;
        }
        if (itemToAdd.isEnemyTooth)
        {
            numberOfEnemyTooth++;
        }
        

    }



}
