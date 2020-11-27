using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    [SerializeReference]
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    public List<GameObject> inventorySlotGameObjects;
    private void Update() {
        UpdateDisplay();
    }
    private void OnEnable()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = inventory.Container.Items[i];

            if (itemsDisplayed.ContainsKey(slot))
            {
                itemsDisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
            }
            else
            {
                CreateObjectInInventory(i, slot);
            }
        }
    }

    void CreateObjectInInventory(int i, InventorySlot slot)
    {
        GameObject inventorySlotGameObject = inventorySlotGameObjects[i];
        inventorySlotGameObject.transform.GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.ID].uiDisplay;
        inventorySlotGameObject.transform.GetChild(0).GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");

        itemsDisplayed.Add(slot, inventorySlotGameObject);
    }
}
