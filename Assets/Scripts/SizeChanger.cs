using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement player;
    int pickupLimiter = 0; //-5 to 5

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = rb.GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Increase")) {
            if(pickupLimiter<5){
            Debug.Log("increase");
            //player.sizeMultiplier += 0.5
            collision.gameObject.IsDestroyed();
                Debug.Log(pickupLimiter);
            } else {
                Debug.Log("can't grow more");
            }
        }
        else if(collision.gameObject.CompareTag("Reduce")) {
            if(pickupLimiter>-5){
            Debug.Log("reduce");
            //player.sizeMultiplier -= 0.5
            collision.gameObject.IsDestroyed();
                Debug.Log(pickupLimiter);
            } else {
                Debug.Log("can't shrink more");
            }
        }
    }
}
