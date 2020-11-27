using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayShop : MonoBehaviour
{
    [SerializeReference]
    public InventoryObject inventory;
    public ShopListObject shopList;
    public List<GameObject> buyInventorySlotGameObjects;
    public List<GameObject> sellInventorySlotGameObjects;
    public List<GameObject> buyInventorySlotCostGameObjects;
    public List<GameObject> sellInventorySlotValueGameObjects;
    [SerializeField]
    GameObject inventoryPanel;
    private void OnEnable()
    {
        UpdateDisplay();
        if (!inventoryPanel.activeInHierarchy)
        {
            inventoryPanel.SetActive(true);
        }
    }

    private void UpdateDisplay()
    {
        for (int i = 0; i < shopList.ItemsForSale.Length; i++)
        {
            CreateObjectInInventorySaleList(i, shopList.ItemsForSale[i].ID);

        }
        for (int i = 0; i < shopList.ItemsToBuy.Length; i++)
        {
            CreateObjectInInventoryBuyList(i, shopList.ItemsToBuy[i].ID);
        }
    }

    void CreateObjectInInventorySaleList(int i, string ID)
    {
        GameObject shopSlotGameObject = sellInventorySlotGameObjects[i];
        GameObject shopSlotValueGameObject = sellInventorySlotValueGameObjects[i];
        ItemObject itemObject = inventory.database.GetItem[ID];
        shopSlotGameObject.transform.GetComponentInChildren<Image>().sprite = itemObject.uiDisplay;
        shopSlotValueGameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text = itemObject.value.ToString("n0");
    }
    void CreateObjectInInventoryBuyList(int i, string ID)
    {
        GameObject shopSlotGameObject = buyInventorySlotGameObjects[i];
        GameObject shopSlotValueGameObject = buyInventorySlotCostGameObjects[i];
        ItemObject itemObject = inventory.database.GetItem[ID];
        shopSlotGameObject.transform.GetComponentInChildren<Image>().sprite = itemObject.uiDisplay;
        shopSlotValueGameObject.transform.GetComponentInChildren<TextMeshProUGUI>().text = itemObject.value.ToString("n0");
    }
}
