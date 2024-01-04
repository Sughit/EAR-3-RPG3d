using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class PlayerMineRock : MonoBehaviour
{
    public InventorySO inventory;
    public SimpleItemSO rock;
    public SimpleItemSO gem;

    [SerializeField]
    bool inRange;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") inRange=true;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player") inRange=false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(GameObject.Find("GameManager").GetComponent<InGameMenu>().inGameMenuGO.activeSelf == false)
            {
                if(inRange)
                {
                    if(Random.Range(0, 11) == 3) 
                    {
                        //play SFX
                        inventory.AddItem(gem, 1, null);
                    }
                    else 
                    {
                        //play SFX
                        inventory.AddItem(rock, 1, null);
                    }
                }
            }
        }
    }
}
