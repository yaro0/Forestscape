using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public TextMeshProUGUI priceText;
    public GameObject shopManager;

    // Update is called once per frame
    void Update()
    {
        priceText.text = shopManager.GetComponent<WorkBenchManager>().purchasableItems[2,ItemID].ToString();
    }
}
