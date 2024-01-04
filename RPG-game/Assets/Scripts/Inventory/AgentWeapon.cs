using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class AgentWeapon : MonoBehaviour
{
    [SerializeField] EquipableItemSO weapon;

    [SerializeField] InventorySO inventoryData;

    [SerializeField] List<ItemParameter> parametersToModify, itemCurrentState;

    public void SetWeapon(EquipableItemSO weaponItemSO, List<ItemParameter> itemState)
    {
        if(weapon != null)
        {
            inventoryData.AddItem(weapon, 1, itemCurrentState);
        }

        this.weapon = weaponItemSO;
        this.itemCurrentState = new List<ItemParameter>(itemState);
        ModifyParameters();
    }

    void ModifyParameters()
    {
        foreach(var parameter in parametersToModify)
        {
            if(itemCurrentState.Contains(parameter))
            {
                int index = itemCurrentState.IndexOf(parameter);
                float newValue = itemCurrentState[index].value + parameter.value;
                itemCurrentState[index] = new ItemParameter
                {
                    itemParameter = parameter.itemParameter,
                    value = newValue
                };
            }
        }
    }
}
