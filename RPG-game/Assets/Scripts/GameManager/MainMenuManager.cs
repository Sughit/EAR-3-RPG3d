using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Animator trans;

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
}
