using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryDescription : MonoBehaviour
{
    [SerializeField]
    Image itemImage;
    [SerializeField]
    Text title;
    [SerializeField]
    Text description;

    void Awake()
    {
        ResetDescription();
    }

    public void ResetDescription()
    {
        this.itemImage.gameObject.SetActive(false);
        this.title.text = "";
        this.description.text = "";
    }

    public void SetDescription(Sprite sprite, string itemName, string itemDescription)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.title.text = itemName;
        this.description.text = itemDescription;
    }
}
