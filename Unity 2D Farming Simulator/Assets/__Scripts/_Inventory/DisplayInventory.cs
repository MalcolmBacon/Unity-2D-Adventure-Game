using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventoryPrefab;
    [SerializeReference]
    public InventoryObject inventory;
    public int xStart;
    public int yStart;
    public int xSpaceBetweenItems;
    public int numberOfColumns;
    public int ySpaceBetweenItems;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    private void Update() {
        if (Input.GetKeyDown(KeyCode.V))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inventory.Load();
        }

        UpdateDisplay();
    }
    private void OnEnable()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        for (int  i = 0; i < inventory.Container.Items.Count; i++)
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

    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpaceBetweenItems * (i % numberOfColumns)), yStart + ((-ySpaceBetweenItems * (i / numberOfColumns))), 0f);
    }
    void CreateObjectInInventory(int i, InventorySlot slot)
    {
        var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
        obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.ID].uiDisplay;
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
        itemsDisplayed.Add(slot, obj);
    }
}
