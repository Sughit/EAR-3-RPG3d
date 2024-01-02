using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Animator trans;
    public GameObject main;
    public GameObject settingsMenu;


    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        trans.SetTrigger("trans");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Settings()
    {
        settingsMenu.SetActive(true);
        main.SetActive(false);
    }
    public void BackSettings()
    {
        main.SetActive(true);
        settingsMenu.SetActive(false);
    }
    
}
