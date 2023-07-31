using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sm;
    
    void Start()
    {
        if (sm == null) 
        {
            sm = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<SoundManager>();
        }
    }

    public AudioSource backgroundMusic;
    public AudioSource pickupKeySound;
    public AudioSource pickupChestSound;
    public AudioSource explosionSound;
    public AudioSource jumpSound;
    public AudioSource cantJumpSound;

    public float startingJumpPitch = 1f;
    public float changingJumpPitch = 0.05f;

    public static void PlayPickupKeySound()
    {
        sm.pickupKeySound.Play();
    }

    public static void PlayPickupChestSound()
    {
        sm.pickupChestSound.Play();
    }

    public static void PlayExplosionSound()
    {
        sm.explosionSound.Play();
    }

    public static void PlayJumpSound()
    {
        //Slightly change pitch of jump sound everytime for variety
        sm.jumpSound.pitch = sm.startingJumpPitch + Random.Range(-sm.changingJumpPitch, sm.changingJumpPitch);
        sm.jumpSound.Play();
    }

    public static void PlayCantJumpSound()
    {
        sm.cantJumpSound.Play();
    }
}
