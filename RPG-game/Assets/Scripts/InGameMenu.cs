using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameMenuGO;
    public GameObject[] menuList;
    [SerializeField] int index;

    void Start()
    {
        menuList[index].SetActive(true);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Tab))
        {
            inGameMenuGO.SetActive(true);
        }
    }

    public void UpMenuList()
    {
        index++;
        if(index == menuList.Length) index = 0;
        menuList[index].SetActive(true);
        if(index != 0) menuList[index-1].SetActive(false);
        else menuList[menuList.Length - 1].SetActive(false);
    }

    public void DownMenuList()
    {
        index--;
        if(index < 0) index = menuList.Length - 1;
        menuList[index].SetActive(true);
        if(index != menuList.Length - 1) menuList[index+1].SetActive(false);
        else menuList[0].SetActive(false);
    }
}
