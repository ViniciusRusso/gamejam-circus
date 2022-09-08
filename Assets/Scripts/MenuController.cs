using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Credits;
    
    public void StartGame()
    {
        PlayerPrefs.SetInt("Level", 0);
        SceneManager.LoadScene("Map");
    }

    public void ShowCredits()
    {
        Credits.SetActive(true);
        Menu.SetActive(false);
    }

    public void HideCredits()
    {
        Credits.SetActive(false);
        Menu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
