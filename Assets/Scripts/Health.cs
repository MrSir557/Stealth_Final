using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GetHealth();
            Destroy(this.gameObject);
        }
    }
}
