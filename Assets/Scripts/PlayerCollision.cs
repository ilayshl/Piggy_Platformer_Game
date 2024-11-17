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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && player.onFloor == false)
        {
            player.ResetJump();
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (player.GetComponent<Transform>().localScale.x >= 1.2f)
            {
                Destroy(other.gameObject);
            }
        }
        playerSFX.PickupSound(other.gameObject.tag);
    }
}
