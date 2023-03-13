using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{

    public int[,] shopItem = new int[5, 5];
    public float coins;
    public TMP_Text CoinsTXT;
    public InventoryData inv;
    
    // Start is called before the first frame update
    void Start()
    {
        CoinsTXT.text = "Coins: " + coins.ToString();

        //ID
        shopItem[1, 1] = 1;
        shopItem[1, 2] = 2;
        shopItem[1, 3] = 3;

        //Price
        shopItem[2, 1] = 10;
        shopItem[2, 2] = 20;
        shopItem[2, 3] = 30;

        //Quantity
        shopItem[3, 1] = inv.item1;
        shopItem[3, 2] = inv.item2;
        shopItem[3, 3] = inv.item3;


      /*  shopItem[3, 1] = 0;
        shopItem[3, 2] = 0;
        shopItem[3, 3] = 0;*/
    }

    // Update is called once per frame
    void Update()
    {
        inv.item1 = shopItem[3, 1];
        inv.item2 = shopItem[3, 2];
        inv.item3 = shopItem[3, 3];
    }

    public void Buy() 
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItem[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            coins -= shopItem[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItem[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTXT.text = "Coins: " + coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItem[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }

    }

}
