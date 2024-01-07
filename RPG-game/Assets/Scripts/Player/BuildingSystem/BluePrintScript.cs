using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class BluePrintScript : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    Quaternion rot;
    public GameObject prefab;
    public bool canPlace = true;

    public InventorySO inventory;
    public ItemSO item1;
    public int quantity1;
    public ItemSO item2;
    public int quantity2;
    public ItemSO item3;
    public int quantity3;

    bool b_item1;
    bool b_item2;
    bool b_item3;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer < 32 && other.gameObject.layer != 7) canPlace =false;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer < 32 && other.gameObject.layer != 7) canPlace =true;
    }

    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit, 5000.0f, (1 << 7)))
        {
            transform.position = hit.point;
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit, 5000.0f, (1 << 7)))
        {
            transform.position = hit.point;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            rot = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 10, transform.rotation.eulerAngles.z);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
        {
            rot = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 10, transform.rotation.eulerAngles.z);
        }
        transform.rotation = rot;
        
        if(Input.GetMouseButton(0) && canPlace)
        {
            if(CheckIfEnoughItems()) 
            {
                Debug.Log(CheckIfEnoughItems());
                Instantiate(prefab, transform.position, transform.rotation);
            }
            else
            {
                if(b_item1) 
                {
                    inventory.AddStackableItem(item1, quantity1);
                    b_item1=false;
                }
                if(b_item2)
                {
                    inventory.AddStackableItem(item2, quantity2);
                    b_item2=false;
                }
                if(b_item3)
                {
                    inventory.AddStackableItem(item3, quantity3);
                    b_item3=false;
                }
            }
            Destroy(gameObject);
        }

        if(Input.GetMouseButton(1))
        {
            Destroy(gameObject);
        }
    }

    bool CheckIfEnoughItems()
    {
        inventory.GetCurrentInventoryState();
        if(item1 != null)
        {
            for(int i = 0; i < inventory.Size; i++)
            {
                if(item1 == inventory.GetItemAt(i).item) 
                {
                    if(quantity1 <= inventory.GetItemAt(i).quantity)
                    {
                        inventory.RemoveItem(i, quantity1);
                        b_item1=true;
                        Debug.Log("Primul item");
                        break;
                    }
                    else if(i == inventory.Size - 1) return false;
                }
                else if(i == inventory.Size - 1) return false;
            }
        }
        if(item2 != null)
        {
            for(int i = 0; i < inventory.Size; i++)
            {
                if(item2 == inventory.GetItemAt(i).item) 
                {
                    if(quantity2 <= inventory.GetItemAt(i).quantity)
                    {
                        inventory.RemoveItem(i, quantity2);
                        b_item2=true;
                        Debug.Log("Al doilea item");
                        break;
                    }
                    else if(i == inventory.Size - 1) return false;
                }
                else if(i == inventory.Size - 1) return false;
            }
        }
        if(item3 != null)
        {
            for(int i = 0; i < inventory.Size; i++)
            {
                if(item3 == inventory.GetItemAt(i).item) 
                {
                    if(quantity3 <= inventory.GetItemAt(i).quantity)
                    {
                        inventory.RemoveItem(i, quantity3);
                        b_item3=true;
                        Debug.Log("Al treilea item");
                        break;
                    }
                    else if(i == inventory.Size - 1) return false;
                }
                else if(i == inventory.Size - 1) return false;
            }
        }
        return true;
    }
}
