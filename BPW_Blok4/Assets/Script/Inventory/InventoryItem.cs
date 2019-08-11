using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool usable;
    public bool unique;
    public UnityEvent thisEvent;

   [Header("Quest Items")]
    public bool isKey;
    public bool isCoin;
    public bool isMasterKey;
    public bool isApple;
    public bool isEnemyTooth;


    public void Use()
    {
        
        thisEvent.Invoke();
        Debug.Log("Use Item");
    }

    public void DecreaseAmount(int amountToDecrease)
    {
        numberHeld -= amountToDecrease;
        if(numberHeld < 0)
        {
            numberHeld = 0;
        }
    }

}
 