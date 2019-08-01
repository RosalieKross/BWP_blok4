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
    public int coins;
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
        else
        {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }

    }



}
