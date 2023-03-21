using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Inventory", menuName="Project/Inventory")]
public class InventoryData : ScriptableObject {
    public List<ItemData> items;
    public int coins;
    public int gems;
}
