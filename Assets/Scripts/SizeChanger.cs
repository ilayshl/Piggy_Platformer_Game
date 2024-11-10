using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public float sizeMultiplier;

    [SerializeField] float playerSizeChange = 0.1f;
    Rigidbody2D rb;
    PlayerMovement player;
    int pickupLimiter = 0; //-5 to 5
    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = rb.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Grow")) {
            Destroy(collision.gameObject);
            if(pickupLimiter<5) {
                pickupLimiter++;
                Debug.Log("increase "+pickupLimiter);
                ChangeSize(playerSizeChange);
                player.boostMultiplier/=1.1f;
            } else {
                Debug.Log("can't grow more");
            }
        } else if(collision.gameObject.CompareTag("Shrink")) {
            Destroy(collision.gameObject);
            if(pickupLimiter>-5) {
                pickupLimiter--;
                Debug.Log("reduce "+pickupLimiter);
                ChangeSize(-playerSizeChange);
                player.boostMultiplier*=1.1f;
            } else {
                Debug.Log("can't shrink more");
            }
        }
    }

    void ChangeSize(float multiplier) {
        gameObject.transform.localScale+=new Vector3(multiplier, multiplier, multiplier);
    }

}
