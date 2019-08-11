using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Inventory : ScriptableObject
{

    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;
    public int numberOfMasterKey;
    public int numberOfApples;
    public int coins;
    public int numberOfEnemyTooth;
    //public int numberOfCoins;

    public void AddItem(Item itemToAdd)
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
        else
        {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }

    }

    

}
