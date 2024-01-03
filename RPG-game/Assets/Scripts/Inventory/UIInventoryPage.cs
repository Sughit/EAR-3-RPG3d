using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    UIInventoryItem itemPrefab;

    [SerializeField]
    RectTransform contentPanel;

    [SerializeField]
    UIInventoryDescription itemDescription;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    public int inventorySize = 10;

    void Awake()
    {
        itemDescription.ResetDescription();
    }

    void Start()
    {
        InitializeInventoryUI();
    }

    public void InitializeInventoryUI()
    {
        for(int i = 0; i < inventorySize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            uiItem.transform.localScale = new Vector3(1, 1, 1);
            listOfUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    void HandleItemSelection(UIInventoryItem obj)
    {

    }

    void HandleBeginDrag(UIInventoryItem obj)
    {
        
    }
    void HandleSwap(UIInventoryItem obj)
    {
        
    }

    void HandleEndDrag(UIInventoryItem obj)
    {
        
    }

    void HandleShowItemActions(UIInventoryItem obj)
    {
        
    }
}
