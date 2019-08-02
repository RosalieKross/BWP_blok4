using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    int moneyAmount;
    int isKeySold;

    public Inventory playerInventory;
    public Item itemBuy;

    public Text moneyAmountText;
    public Text keyPrice;

    public Button buyButton;


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

        if(playerInventory.coins >= 5 && isKeySold == 0)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }

    public void buyKey()
    {
        playerInventory.coins -= 5;

        playerInventory.AddItem(itemBuy);
        playerInventory.currentItem = itemBuy;

        //PlayerPrefs.SetInt("isKeySold", 1);
        //keyPrice.text = "sold!";
        //buyButton.gameObject.SetActive(false);
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

