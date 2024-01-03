using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector]
    public UIInventoryPage inventoryUI;

    [SerializeField]
    InventorySO inventoryData;

    void Awake()
    {
        inventoryUI = GameObject.Find("GameManager").GetComponent<GivePlayerScripts>().uiInventoryPage;
    }

    void Start()
    {
        PrepareUI();
        //inventoryData.Initialize();
    }

    void PrepareUI()
    {
        inventoryUI.InitializeInventoryUI(inventoryData.Size);
        this.inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
        this.inventoryUI.OnSwapItems += HandleSwapItems;
        this.inventoryUI.OnStartDragging += HandleDragging;
        this.inventoryUI.OnItemActionRequested += HandleItemActionRequest;
    }

    void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
        if(inventoryItem.IsEmpty) 
        {
            inventoryUI.ResetSelection();
            return;
        }
        ItemSO item = inventoryItem.item;
        inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.name, item.Description);
    }

    void HandleSwapItems(int itemIndex1, int itemIndex2)
    {

    }

    void HandleDragging(int itemIndex)
    {

    }

    void HandleItemActionRequest(int itemIndex)
    {

    }

    void Update()
    {
        if(inventoryUI.gameObject.activeSelf)
        {
            foreach(var item in inventoryData.GetCurrentInventoryState())
            {
                inventoryUI.UpdateData(item.Key,
                    item.Value.item.ItemImage,
                    item.Value.quantity);
            }
        }
    }
}
