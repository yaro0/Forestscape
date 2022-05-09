using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class WorkBenchManager : MonoBehaviour
{
    public int[,] purchasableItems = new int[3,5];
    private int money;

    public PlayerCurrency playerMoney;
    public TextMeshProUGUI moneyText;

    public InventoryScript inventory;
    // Start is called before the first frame update
    void Start()
    {
        money = playerMoney.Money;
        
        moneyText.text = "Coins: " + money.ToString();

        //ID
        purchasableItems[1,1] = 1;
        purchasableItems[1,2] = 2;
        purchasableItems[1,3] = 3;
        purchasableItems[1,4] = 4;

        //Price
        purchasableItems[2,1] = 10;
        purchasableItems[2,2] = 20;
        purchasableItems[2,3] = 30;
        purchasableItems[2,4] = 40;


    }

    // Update is called once per frame
    public void Buy()
    {
      GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

      if(money >= purchasableItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID])
      {
         money -= purchasableItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID];
         moneyText.text = "Coins: " + money.ToString();
         activateUpgrade(ButtonRef);
      }

        playerMoney.playerMoney = money; 

    }

    public void activateUpgrade(GameObject button){
      inventory.inventory[button.GetComponent<ButtonInfo>().ItemID] = true;
    }

}
