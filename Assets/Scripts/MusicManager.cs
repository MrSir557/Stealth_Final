using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource idle;
    public AudioSource suspect;
    public AudioSource chase;

    public void idleMusic()
    {
        idle.mute = false;
        suspect.mute = true;
        chase.mute = true;
    }

    public void suspectMusic()
    {
        idle.mute = true;
        suspect.mute = false;
        chase.mute = true;
    }

    public void chaseMusic()
    {
        idle.mute = true;
        suspect.mute = true;
        chase.mute = false;;
    }
}
