using UnityEngine;

[CreateAssetMenu(fileName="Item", menuName="Project/Item")]
public class ItemData: ScriptableObject
{
	public string itemName;
	public Sprite sprite;
	public float spriteRotation;
	public int coinCost;
	public int gemCost;
	public int quantity;
	public Rarity rarity;
}

public enum Rarity {SSR, SR, R}
