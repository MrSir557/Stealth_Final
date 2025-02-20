using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool hasKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
            hasKey = GameObject.Find("GameManager").GetComponent<GameManager>().hasKey;

            if(hasKey)
                SceneManager.LoadScene("Win");
        }
    }
}