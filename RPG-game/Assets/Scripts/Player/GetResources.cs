using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class GetResources : MonoBehaviour
{
    public InventorySO inventory;
    public SimpleItemSO simpleResource;
    public SimpleItemSO rareResource;

    public float range = 2.5f;

    public InGameMenu gameManager;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch(SelectClass._class)
            {
                case "l_melee":
                player.GetComponent<LightAttack>().inRangeOfUtilities = true;
                break;
                case "h_melee":
                player.GetComponent<HeavyAttack>().inRangeOfUtilities = true;
                break;
                case "l_range":
                player.GetComponent<LightRange>().inRangeOfUtilities = true;
                break;
                case "h_range":
                player.GetComponent<HeavyRange>().inRangeOfUtilities = true;
                break;
                default:
                Debug.Log("The class does not exist");
                break;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch(SelectClass._class)
            {
                case "l_melee":
                player.GetComponent<LightAttack>().inRangeOfUtilities = false;
                break;
                case "h_melee":
                player.GetComponent<HeavyAttack>().inRangeOfUtilities = false;
                break;
                case "l_range":
                player.GetComponent<LightRange>().inRangeOfUtilities = false;
                break;
                case "h_range":
                player.GetComponent<HeavyRange>().inRangeOfUtilities = false;
                break;
                default:
                Debug.Log("The class does not exist");
                break;
            }
        }
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<InGameMenu>();
    }

    void Update()
    {
        if(player == null) player = GameObject.FindWithTag("Player");
        
        if(Input.GetMouseButtonDown(0))
        {
            if(gameManager.inGameMenuGO.activeSelf == false && player != null)
            {
                Use();
            }
        }
    }

    void Use()
    {
        if(Vector3.Distance(player.transform.position, transform.position) <= range)
        {
            if(Random.Range(0, 11) == 3) 
            {
                if(rareResource != null)
                {
                    //play rare SFX
                    inventory.AddItem(rareResource, 1, null);
                }
                else
                {
                    //play simple SFX
                    inventory.AddItem(simpleResource, 1, null);
                }
            }
            else 
            {
                //play simple SFX
                inventory.AddItem(simpleResource, 1, null);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
