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
    void Start()
    {
        money = playerMoney.Money;
        
        moneyText.text = money.ToString();

        //ID
        purchasableItems[1,1] = 1;
        purchasableItems[1,2] = 2;
        purchasableItems[1,3] = 3;
        purchasableItems[1,4] = 4;

        //Price
        purchasableItems[2,1] = 100;
        purchasableItems[2,2] = 200;
        purchasableItems[2,3] = 300;
        purchasableItems[2,4] = 400;


    }

    ///<summary>
    ///Fait l'achat d'un atout et enlève l'argent du joueur
    ///</summary>
    public void Buy()
    {
      GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

      if(money >= purchasableItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID])
      {
         money -= purchasableItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID];
         moneyText.text = money.ToString();
         activateUpgrade(ButtonRef);
      }

        playerMoney.playerMoney = money; 

    }

    ///<summary>
    ///Active l'atout choisi
    ///</summary>
    public void activateUpgrade(GameObject button){
      inventory.inventory[button.GetComponent<ButtonInfo>().ItemID] = true;
    }

}
