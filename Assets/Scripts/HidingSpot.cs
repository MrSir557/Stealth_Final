using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
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
            //I hit the player!
            GameObject.Find("GameManager").GetComponent<GameManager>().isHiding();
        }
    }

    private void OnTriggerExit(Collider whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
            //I hit the player!
            GameObject.Find("GameManager").GetComponent<GameManager>().isVisible();
        }
    }
}
