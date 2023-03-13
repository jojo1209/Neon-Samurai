using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public TMP_Text PriceTxt;
    public TMP_Text QuantityTxt;
    public GameObject ShopManager;

    // Update is called once per frame
    void Update()
    {
        PriceTxt.text = "Price: " + ShopManager.GetComponent<ShopManager>().shopItem[2,ItemID].ToString() + " Gold or " + ShopManager.GetComponent<ShopManager>().shopItem[4, ItemID].ToString() + " Gems";
        QuantityTxt.text = ShopManager.GetComponent<ShopManager>().shopItem[3, ItemID].ToString();
    }
}
