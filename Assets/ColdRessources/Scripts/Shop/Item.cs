using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item: MonoBehaviour { 
	public ItemData itemData;
	[SerializeField] private TMP_Text coinPriceLabel;
	[SerializeField] private TMP_Text gemPriceLabel;
	[SerializeField] private TMP_Text nameLabel;
	[SerializeField] private TMP_Text quantityLabel;
	[SerializeField] private Image spriteImage;

	private void Start() {
		coinPriceLabel.text = $"{itemData.coinCost}";
		gemPriceLabel.text = $"{itemData.gemCost}";
		
		nameLabel.text = itemData.itemName;
		nameLabel.color = itemData.rarity switch {
			Rarity.R   => new Color(1.0f, 0.0f, 1.0f),
			Rarity.SR  => new Color(1.0f, 0.5f, 0.0f),
			Rarity.SSR => new Color(1.0f, 0.2f, 0.2f),
			_ => Color.white
		};
		
		spriteImage.sprite = itemData.sprite;
		spriteImage.transform.rotation = Quaternion.Euler(0, 0, itemData.spriteRotation);
		
		UpdateQuantity();
	}

	public void UpdateQuantity() {
		quantityLabel.text = $"{itemData.quantity}";
	}
}
