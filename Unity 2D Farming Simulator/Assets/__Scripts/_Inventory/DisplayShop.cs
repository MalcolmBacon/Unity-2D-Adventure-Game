using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayShop : MonoBehaviour
{
    [SerializeReference]
    public InventoryObject inventory;
    public ShopListObject shopList;
    public FloatObject currentPlayerHealth;
    public Observer playerHealthObserver;
    public List<GameObject> buyInventorySlotGameObjects;
    public List<GameObject> sellInventorySlotGameObjects;
    public List<GameObject> buyInventorySlotCostGameObjects;
    public List<GameObject> sellInventorySlotValueGameObjects;
    [SerializeField]
    GameObject inventoryPanel;
    [SerializeField]
    private string currencyID = "GoldCoin";
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
    public void CloseShop()
    {
        this.gameObject.SetActive(false);
        inventoryPanel.SetActive(false);
    }
    public void BuyItem(Transform transform)
    {
        int indexOfButton = transform.GetSiblingIndex();
        if (indexOfButton < shopList.ItemsToBuy.Length)
        {
            EquipmentObject itemToBuy = shopList.ItemsToBuy[indexOfButton];
            if (inventory.BuyItem(itemToBuy, currencyID))
            {
                currentPlayerHealth.maxRunTimeValue = currentPlayerHealth.maxRunTimeValue + (itemToBuy.defenceBonus * 2);
                currentPlayerHealth.runTimeValue = currentPlayerHealth.maxRunTimeValue;
                playerHealthObserver.Raise();
            }
        }
    }
    public void SellItem(Transform transform)
    {
        int indexOfButton = transform.GetSiblingIndex();
        if (indexOfButton < shopList.ItemsForSale.Length)
        {
            ItemObject itemForSale = shopList.ItemsForSale[indexOfButton];
            inventory.SellItem(itemForSale, currencyID);
        }

    }
}
