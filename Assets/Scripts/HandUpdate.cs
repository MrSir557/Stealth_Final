using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUpdate : MonoBehaviour
{
    public Sprite hand_green;
    public Sprite hand_yellow;
    public Sprite hand_orange;
    public Sprite hand_red;
    private SpriteRenderer render;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        health = GameObject.Find("GameManager").GetComponent<GameManager>().health;

        switch(health)
        {
            case 1:
                render.sprite = hand_red;
                break;
            case 2:
                render.sprite = hand_orange;
                break;
            case 3:
                render.sprite = hand_yellow;
                break;
            case 4:
                render.sprite = hand_green;
                break;
        }
    }
}
