using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider whatIHit)
    {
        if(whatIHit.tag == "Player" && gameManager.hasKey)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
