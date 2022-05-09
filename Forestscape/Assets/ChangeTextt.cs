using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextt : MonoBehaviour
{
    
    [SerializeField] private PlayerCurrency playerMoney;


    public Text changingText;

    private float money;

    // Start is called before the first frame update
    void Start()
    {
        money = playerMoney.Money;
        TextChange();
    }

    public void TextChange()
    {
        changingText.text = money.ToString();
    }

}
