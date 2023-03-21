using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager: MonoBehaviour {
	[SerializeField] private TMP_Text coinsTxt;
	[SerializeField] private TMP_Text gemsTxt;
	[SerializeField] private InventoryData inventoryData;
	[SerializeField] private Item itemPrefab;
	[SerializeField] private VerticalLayoutGroup itemsContainer;
	private List<Item> items;

	private void Awake() {
		items = new List<Item>();
	}
	
	private void Start() {
		for (int i = 0; i < inventoryData.items.Count; i++) {
			// create an item instance
			Item item = Instantiate(itemPrefab, itemsContainer.transform);
			
			// set item data (it will create itself from it in its Start method)
			ItemData itemData = inventoryData.items[i];
			item.itemData = itemData;
			
			// add event on click
			var itemId = i;
			item.GetComponent<Button>().onClick.AddListener(() => Buy(itemId));
			
			// register the item in the item list
			items.Add(item);
		}
		
		// update currency text
		UpdateCoin();
		UpdateGems();
	}

	public void Buy(int itemId)
	{
		// retrieve the cost of the item
		var coinCost = inventoryData.items[itemId].coinCost;
		var gemCost = inventoryData.items[itemId].gemCost;
		
		// verify if we can pay it
		var canPayWithCoins = inventoryData.coins >= coinCost;
		var canPay = canPayWithCoins || inventoryData.gems >= gemCost;;

		// if we can't, just ignore the transaction
		if (!canPay) return;
		
		// increment the item count
		inventoryData.items[itemId].quantity++;

		// decrease the currency used
		if (canPayWithCoins) {
			inventoryData.coins -= coinCost;
			UpdateCoin();
		}
		else {
			inventoryData.gems -= gemCost;
			UpdateGems();
		}
		
		// update the quantity text
		items[itemId].UpdateQuantity();
	}

	private void UpdateCoin() { coinsTxt.text = $"     {inventoryData.coins}"; }
	private void UpdateGems() { gemsTxt.text = $"     {inventoryData.gems}"; }
}