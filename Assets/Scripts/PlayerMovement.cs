using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource audioPlay;
    public AudioClip taser;
    public bool isPlaying;
    public AudioClip ropeClimb;
    public AudioClip walking;
    public float MoveSmoothTime;
    public float Speed;
    public bool climbing;
    public bool hasTaser;
    public GameObject taserProjectile;
    
    public Vector3 PlayerInput;
    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;
    public GameObject taserHUD;

    public GameManager gameManager;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical"),
        };

        if(climbing)
        {
            PlayerInput.y = Input.GetAxisRaw("Vertical");
            PlayerInput.z = 0f;
        }

        if(PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        Vector3 MoveVector = transform.TransformDirection(PlayerInput);

        CurrentMoveVelocity = Vector3.SmoothDamp(
            CurrentMoveVelocity,
            MoveVector * Speed,
            ref MoveDampVelocity,
            MoveSmoothTime
        );
        
        if(!climbing)
        {
            CurrentMoveVelocity.y -= 98f * Time.deltaTime;

            if(PlayerInput.x == 0 && PlayerInput.z ==0)
            {
                audioPlay.clip = walking;
                audioPlay.Play();
            }
        }

        Controller.Move(CurrentMoveVelocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && hasTaser)
            UseTaser();
    }

    void OnTriggerStay (Collider whatIHit)
    {
        if(whatIHit.tag == "Ladder")
        {
            climbing = true;
                
                if(!isPlaying)
                {
                    isPlaying = true;
                    audioPlay.volume = 0.5f;
                    audioPlay.clip = ropeClimb;
                    audioPlay.Play();
                }
        }

        else if (whatIHit.tag == "HidingSpot")
        {
            gameManager.isHiding();
        }
    }

    void OnTriggerExit (Collider whatIHit)
    {
        if(whatIHit.tag == "Ladder")
        {
            climbing = false;
            audioPlay.Stop();
            isPlaying = false;
        }

        else if (whatIHit.tag == "HidingSpot")
        {
            gameManager.isVisible();
        }
    }

    public void GetTaser()
    {
        hasTaser = true;
        taserHUD.SetActive(true);
    }
    void UseTaser()
    {
        hasTaser = false;
        taserHUD.SetActive(false);
        audioPlay.clip = taser;
        audioPlay.Play();

        Instantiate(taserProjectile, transform.position, Quaternion.identity);
    }
}