using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    
    public Image credits;
    public Image Exit;

    void Start()
    {
        credits.GetComponent<Image>();
        credits.enabled = false;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("ArtTest");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
