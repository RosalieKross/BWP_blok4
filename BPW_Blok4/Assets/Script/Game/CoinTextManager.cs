using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public TextMeshProUGUI coinDisplay;
    public float currentCoinAmount;

    public void Start()
    {
        coinDisplay.text = "" + playerInventory.coins;
    }

    public void UpdateCoinCount()
    {
        coinDisplay.text = "" + playerInventory.coins; 
    }
}
