using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip startingSound;
    [SerializeField] AudioClip lastJumpSound;
    [SerializeField] AudioClip[] jumpSounds;
    [SerializeField] AudioClip[] playerJumpSounds;
    [SerializeField] AudioClip[] pickupSounds;
    [SerializeField] AudioClip obstaclesSound;
    PlayerMovement player;
    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    public void JumpSound(int jumps) {
        audioSource.pitch=Random.Range(0.8f, 1.2f);
        if(jumps==0) {
            audioSource.PlayOneShot(lastJumpSound);
        } else {
            audioSource.PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);
            audioSource.PlayOneShot(playerJumpSounds[Random.Range(0, playerJumpSounds.Length)]);
        }
    }

    public void StartSound() {
        if(audioSource.isPlaying==false){
        audioSource.PlayOneShot(startingSound);
        }
    }

    public void PickupSound(string tag) {
        audioSource.pitch=1;
        if(tag == "Grow") {
            audioSource.PlayOneShot(pickupSounds[0]);
        }
        else if(tag =="Shrink") {
            audioSource.PlayOneShot(pickupSounds[1]);
        }
        else if(tag =="Extra Jump") {
            audioSource.PlayOneShot(pickupSounds[2]);
        }
        else if (tag =="Extra Time") {
            audioSource.PlayOneShot(pickupSounds[3]);
        }else if(tag =="Obstacle") {
            audioSource.PlayOneShot(obstaclesSound);
        }
    }
}
