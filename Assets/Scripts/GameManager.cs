using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int health = 4;
    public float iFrames = 1.0f;
    float m_DamageCooldown = 0;

    public bool hasKey;
    public Animator anim;
    public Animator stealthAnim; 
    
    public Transform playerPosition;
    public bool hiding = false;
    public bool isChased = false;


    public GameObject stealthHUD;
    public GameObject keyHUD;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(hiding && !isChased)
        {
            //hidden sprite
            stealthAnim.SetBool("Hidden", true);
            stealthAnim.SetBool("Caught", false);
        }

        else if(!isChased)
        {
            //normal sprite
            stealthAnim.SetBool("Hidden", false);
            stealthAnim.SetBool("Caught", false);
        }

        else
        {
            //chase sprite
            stealthAnim.SetBool("Hidden", false);
            stealthAnim.SetBool("Caught", true);
        }
        
        if(m_DamageCooldown > 0)
        {
            m_DamageCooldown -= Time.deltaTime;
        }
    }

    public void LoseHealth()
    {
        if(m_DamageCooldown > 0)
            return;
        
        m_DamageCooldown = iFrames;

        health--;
        anim.SetInteger("Health", health);

        if(health == 0)
        {
            SceneManager.LoadScene("Lose");
        }
        
    }
    public void GetHealth()
    {
        if(health < 4)
        {
            health++;
            anim.SetInteger("Health", health);
        }
    }

    public void GetKey()
    {
        hasKey = true;
        keyHUD.SetActive(true);
    }

    public void isHiding()
    {
        hiding = true;
    }

    public void isVisible()
    {
        hiding = false;
    }
}
