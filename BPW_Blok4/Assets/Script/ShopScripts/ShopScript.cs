using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopScript : MonoBehaviour
{
    int moneyAmount;
    int isKeySold;
    int isPotionSold;

    public PlayerInventory playerInventory;
    public InventoryItem thisItem;
    public InventoryItem thisPotion;
    public InventoryItem thisCoin;


    public Text moneyAmountText;
    public Text keyPrice;

    public Button buyButton;
    public Button buyButton2;


    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    [Header("SceneTransition Variables")]
    public Vector2 cameraNewMax;
    public Vector2 cameraNewMin;
    public VectorValue cameraMin;
    public VectorValue cameraMax;



    // Start is called before the first frame update
    void Start()
    {
        //playerInventory.coins = PlayerPrefs.GetInt("MoneyAmount"); 
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = "Current amount of money: $" + playerInventory.coins.ToString();

        //isKeySold = PlayerPrefs.GetInt("isKeySlod");

        if(playerInventory.coins >= 5 && isPotionSold == 0)
        {
            buyButton2.interactable = true;
            
        }
        if (playerInventory.coins >= 5 && isKeySold == 0)
        {
            buyButton.interactable = true;
            
        }
        else
        {
            buyButton2.interactable = false;
            buyButton.interactable = false;
        }
    }

    public void buyKey()
    {
        SoundManager.PlayeSound("Click");
        playerInventory.coins -= 5;
        RemoveFromInventory();
        playerInventory.AddItem(thisItem);
        
        //playerInventory.currentItem = thisItem;
        AddItemToInventory();
        //PlayerPrefs.SetInt("isKeySold", 1);
        //keyPrice.text = "sold!";
        //buyButton.gameObject.SetActive(false);
    }

    public void buyPotion()
    {
        SoundManager.PlayeSound("Click");
        playerInventory.coins -= 5;
        RemoveFromInventory();
        playerInventory.AddItem(thisPotion);
        
        //playerInventory.currentItem = thisItem;
        AddPotionToInventory();
        //PlayerPrefs.SetInt("isKeySold", 1);
        //keyPrice.text = "sold!";
        //buyButton.gameObject.SetActive(false);
    }

    void RemoveFromInventory()
    {

        if (playerInventory && thisCoin)
        {
            if (playerInventory.myInventory.Contains(thisCoin))
            {
                thisCoin.numberHeld -= 5;
            }
            else
            {
                playerInventory.myInventory.Add(thisCoin);
                thisCoin.numberHeld -= 5;
            }
        }
    }


    void AddItemToInventory()
    {

        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }

    void AddPotionToInventory()
    {

        if (playerInventory && thisPotion)
        {
            if (playerInventory.myInventory.Contains(thisPotion))
            {
                thisPotion.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(thisPotion);
                thisPotion.numberHeld += 1;
            }
        }
    }

    public void ResetCameraBounds()
    {
        cameraMax.initialValue = cameraNewMax;
        cameraMin.initialValue = cameraNewMin;
    }


    public void exitShop()
    {
        //PlayerPrefs.SetInt("moneyAmount", playerInventory.coins);

        playerStorage.initialValue = playerPosition;
        SceneManager.LoadScene("SampleScene");
        ResetCameraBounds();


    }


    
}

