using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SelectClass : MonoBehaviour
{
    public GameObject classMenu;
    bool canShowClassMenu=true;
    public static string _class;
    public GameObject lightMelee, heavyMelee, lightRange, heavyRange;
    public Transform spawnPoint;

    public CinemachineVirtualCamera vcam;
    GameObject _player;

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
        _player = Instantiate(lightMelee, spawnPoint.position, Quaternion.identity);
        vcam.Follow = _player.transform;
    }

    public void ChooseHeavyMelee()
    {
        _class="h_melee";
        classMenu.SetActive(false);
        _player = Instantiate(heavyMelee, spawnPoint.position, Quaternion.identity);
        vcam.Follow = _player.transform;
    }

    public void ChooseLightRange()
    {
        _class="l_range";
        classMenu.SetActive(false);
        _player = Instantiate(lightRange, spawnPoint.position, Quaternion.identity);
        vcam.Follow = _player.transform;
    }

    public void ChooseHeavyRange()
    {
        _class="h_range";
        classMenu.SetActive(false);
        _player = Instantiate(heavyRange, spawnPoint.position, Quaternion.identity);
        vcam.Follow = _player.transform;
    }
}
