using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class SimpleItemSO : ItemSO, IDestroyableItem, IItemAction
    {
        [SerializeField]
        List<ModifierData> modifiersData = new List<ModifierData>();

        public string ActionName => "Use";
        
        [field: SerializeField]
        public AudioClip actionSFX {get; private set;}
        
        public bool PerformAction(GameObject character, List<ItemParameter> itemState = null)
        {
            Effect();
            return true;
        }

        public virtual void Effect()
        {
            Debug.Log("Item used");
        }
    }
}
