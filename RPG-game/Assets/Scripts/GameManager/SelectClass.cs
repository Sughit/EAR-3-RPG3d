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
    public Animator anim;

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
        StartCoroutine(ClassSelected());
        InGameMenu.skillTreeIndex = 0;
        _player = Instantiate(lightMelee, spawnPoint.position, Quaternion.identity);
        vcam.Follow = _player.transform;
    }

    public void ChooseHeavyMelee()
    {
        _class="h_melee";
        StartCoroutine(ClassSelected());
        InGameMenu.skillTreeIndex = 1;
        _player = Instantiate(heavyMelee, spawnPoint.position, Quaternion.identity);
        vcam.Follow = _player.transform;
    }

    public void ChooseLightRange()
    {
        _class="l_range";
        StartCoroutine(ClassSelected());
        InGameMenu.skillTreeIndex = 2;
        _player = Instantiate(lightRange, spawnPoint.position, Quaternion.identity);
        vcam.Follow = _player.transform;
    }

    public void ChooseHeavyRange()
    {
        _class="h_range";
        StartCoroutine(ClassSelected());
        InGameMenu.skillTreeIndex = 3;
        _player = Instantiate(heavyRange, spawnPoint.position, Quaternion.identity);
        vcam.Follow = _player.transform;
    }

    IEnumerator ClassSelected()
    {
        anim.SetTrigger("classSelected");
        yield return new WaitForSeconds(.5f);
        classMenu.gameObject.SetActive(false);
    }
}
