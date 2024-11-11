using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public float sizeMultiplier;

    [SerializeField] float playerSizeChange = 0.1f;
    [SerializeField] TextSpawner floatingText;
    Rigidbody2D rb;
    PlayerMovement player;
    int pickupLimiter = 0; //-5 to 5
    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = rb.GetComponent<PlayerMovement>();
        floatingText = player.GetComponent<TextSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Grow")) {
            Destroy(collision.gameObject);
            if(pickupLimiter<5) {
                pickupLimiter++;
                ChangeSize(playerSizeChange);
                player.boostMultiplier/=1.1f;
                floatingText.SetText("+SIZE", collision.transform.position);
            } else {
                floatingText.SetText("Can't grow!", collision.transform.position);
            }
        } else if(collision.gameObject.CompareTag("Shrink")) {
            Destroy(collision.gameObject);
            if(pickupLimiter>-5) {
                pickupLimiter--;
                ChangeSize(-playerSizeChange);
                player.boostMultiplier*=1.1f;
                floatingText.SetText("-SIZE", collision.transform.position);
            } else {
                floatingText.SetText("Can't shrink!", collision.transform.position);
            }
        }
            else if(collision.gameObject.CompareTag("Extra Jump")) {
                Destroy(collision.gameObject);
                    player.SetJumpValue(player.extraJumpValue+1);
            floatingText.SetText("+JUMP", collision.transform.position);
            }
    }

    void ChangeSize(float multiplier) {
        gameObject.transform.localScale+=new Vector3(multiplier, multiplier, multiplier);
    }

}
