using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource playAudio;
    public AudioClip healthAudio;
    public AudioClip noHealthAudio;
    public AudioClip boneCrack;
    public bool isPlaying;
    public AudioClip damageSound;
    public int health = 4;
    public float iFrames = 1.0f;
    float m_DamageCooldown = 0;

    public bool hasKey;
    public Animator anim;
    public Animator stealthAnim;
    public Animator borderAnim; 
    
    public Transform playerPosition;
    public bool hiding = false;
    public bool isChased = false;


    public GameObject keyHUD;
    public GameObject borderHUD;

    // Start is called before the first frame update
    void Start()
    {
        playAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
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
        if(m_DamageCooldown > 0 || !isChased)
            return;
    
        m_DamageCooldown = iFrames;

        playAudio.clip = damageSound;
        playAudio.Play();
            
        health--;
        anim.SetInteger("Health", health);
            
        borderHUD.SetActive(true);
        borderAnim.SetInteger("Health", health);

        if(health == 1)
        {
            playAudio.clip = boneCrack;
            playAudio.Play();
        }

        if(health == 0)
            SceneManager.LoadScene("Lose");
    }
    public void GetHealth()
    {
        if(health < 4)
        {
            health++;
            
            if(health == 4)
                borderHUD.SetActive(false);

            playAudio.clip = healthAudio;
            playAudio.Play();

            anim.SetInteger("Health", health);
            borderAnim.SetInteger("Health", health);
        }

        else if(health == 4)
        {
            playAudio.clip = noHealthAudio;
            playAudio.Play();
        }
    }

    public void GetKey()
    {
        hasKey = true;
        keyHUD.SetActive(true);
    }

    public void isHiding()
    {
        if(!isChased)
            hiding = true;
    }

    public void isVisible()
    {
        hiding = false;
    }
}
