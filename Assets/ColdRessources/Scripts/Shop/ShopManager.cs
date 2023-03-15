using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{

    public int[,] shopItem = new int[5, 5];
    public TMP_Text CoinsTXT;
    public TMP_Text GemsTXT;
    public InventoryData inv;
    
    // Start is called before the first frame update
    void Start()
    {
        CoinsTXT.text = "     " + inv.coins.ToString();
        GemsTXT.text = "     " + inv.gems.ToString();


        //ID
        shopItem[1, 1] = 1;
        shopItem[1, 2] = 2;
        shopItem[1, 3] = 3;

        //Price
        shopItem[2, 1] = 400;
        shopItem[2, 2] = 200;
        shopItem[2, 3] = 50;

        //Quantity
        shopItem[3, 1] = inv.item1;
        shopItem[3, 2] = inv.item2;
        shopItem[3, 3] = inv.item3;

        //Price Gem
        shopItem[4, 1] = 15;
        shopItem[4, 2] = 10;
        shopItem[4, 3] = 5;

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

        if (inv.coins >= shopItem[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            inv.coins -= shopItem[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItem[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTXT.text = "     " + inv.coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItem[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
        else if (inv.gems >= shopItem[4, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            inv.gems -= shopItem[4, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItem[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            GemsTXT.text = "     " + inv.gems.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItem[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }

    }

}
