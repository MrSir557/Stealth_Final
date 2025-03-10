using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    
    public GameObject credits;
    public GameObject exitCredits;

    void Start()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("ArtTest");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        credits.SetActive(true);
        exitCredits.SetActive(true);
    }

    public void ExitCredits()
    {
        Debug.Log("Exit used");
        credits.SetActive(false);
        exitCredits.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
