using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerMovement player;
    PlayerSFX playerSFX;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerSFX = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSFX>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")&&player.onFloor==false) {
            player.ResetJump();
        }
        if(other.gameObject.CompareTag("Obstacle")) {
            Debug.Log("check 1");
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().localScale.x>=1.2f) {
                Destroy(other.gameObject);
                Debug.Log("check 1");
            }
        }
        playerSFX.PickupSound(other.gameObject.tag);
    }
}
