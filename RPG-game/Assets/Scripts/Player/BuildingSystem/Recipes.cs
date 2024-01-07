using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipes : MonoBehaviour
{
    public BluePrintScript building;

    public Image item1;
    public Text quantity1;
    public Image item2;
    public Text quantity2;
    public Image item3;
    public Text quantity3;

    void Update()
    {
        if(this.gameObject.activeSelf)
        {
            //item1
            if(building.item1 != null)
            {
                item1.sprite = building.item1.ItemImage;
                quantity1.text = $"x{building.quantity1}";
            }
            else
            {
                item1.gameObject.SetActive(false);
                quantity1.gameObject.SetActive(false);
            }
            //item2
            if(building.item2 != null)
            {
                item2.sprite = building.item2.ItemImage;
                quantity2.text = $"x{building.quantity2}";
            }
            else
            {
                item2.gameObject.SetActive(false);
                quantity2.gameObject.SetActive(false);
            }
            //item3
            if(building.item3 != null)
            {
                item3.sprite = building.item3.ItemImage;
                quantity3.text = $"x{building.quantity3}";
            }
            else
            {
                item3.gameObject.SetActive(false);
                quantity3.gameObject.SetActive(false);
            }
        }
    }
}
