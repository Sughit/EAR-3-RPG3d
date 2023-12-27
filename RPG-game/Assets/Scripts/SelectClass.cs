using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectClass : MonoBehaviour
{
    public GameObject classMenu;
    bool canShowClassMenu=true;
    public static string _class;
    public GameObject lightMelee, heavyMelee, lightRange, heavyRange;
    public Transform spawnPoint;

    void Start()
    {
        if(canShowClassMenu)
        {
            classMenu.SetActive(true);
            canShowClassMenu=false;
        }
    }

    public void ChooseLightMelee()
    {
        _class="l_melee";
        classMenu.SetActive(false);
        Instantiate(lightMelee, spawnPoint.position, Quaternion.identity);
    }

    public void ChooseHeavyMelee()
    {
        _class="h_melee";
        classMenu.SetActive(false);
        Instantiate(heavyMelee, spawnPoint.position, Quaternion.identity);
    }

    public void ChooseLightRange()
    {
        _class="l_range";
        classMenu.SetActive(false);
        Instantiate(lightRange, spawnPoint.position, Quaternion.identity);
    }

    public void ChooseHeavyRange()
    {
        _class="h_range";
        classMenu.SetActive(false);
        Instantiate(heavyRange, spawnPoint.position, Quaternion.identity);
    }
}
