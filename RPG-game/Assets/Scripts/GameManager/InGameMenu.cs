using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject buildMenu;
    public GameObject inGameMenuGO;
    public GameObject[] menuList;
    [SerializeField] int index;
    public GameObject[] skillTrees;
    public static int skillTreeIndex = 0;

    void Start()
    {
        menuList[index].SetActive(true);
    }

    public void ResetTimeScale()
    {
        Time.timeScale=1;
    }

    void Update()
    {
        //setam pe pozitia de la skill tree, ce skill tree am ales
        menuList[2] = skillTrees[skillTreeIndex];
        if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab)) && !buildMenu.activeSelf)
        {
            inGameMenuGO.SetActive(true);
            //nu stiu cum o sa facem daca vrem sa fie co-op la un moment dat
            //Time.timeScale=0;
        }
        if(Input.GetKeyDown(KeyCode.B) && !inGameMenuGO.activeSelf)
        {
            if(buildMenu.activeSelf)
            {
                buildMenu.SetActive(false);
                CameraZoom.canRotCam = true;
            }
            else
            {
                buildMenu.SetActive(true);
                CameraZoom.canRotCam = false;
            }
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
