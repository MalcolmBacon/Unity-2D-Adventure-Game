using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop List", menuName = "Inventory System/Shop List")]
public class ShopListObject : ScriptableObject
{
    public ItemObject[] ItemsForSale;
    public EquipmentObject[] ItemsToBuy;
}
