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
    PlayerSFX playerSFX;
    TextSpawner floatingText;
    int pickupLimiter = 0; //-5 to 5


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerMovement>();
        playerSFX = GetComponent<PlayerSFX>();
        floatingText = GameObject.FindGameObjectWithTag("Spawner").GetComponent<TextSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.gamePaused) return;
        if(gameObject.CompareTag("Player"))
            {
        if (collision.gameObject.CompareTag("Grow"))
        {
            Destroy(collision.gameObject);
            if (pickupLimiter < 5)
            {
                floatingText.SetText("+SIZE", collision.transform.position);
                pickupLimiter++;
                ChangeSize(playerSizeChange);
                player.boostMultiplier /= 1.1f;
            }
            else
            {
                floatingText.SetText("Can't grow!", collision.transform.position);
            }
        }
        else if (collision.gameObject.CompareTag("Shrink"))
        {
            Destroy(collision.gameObject);
            if (pickupLimiter > -5)
            {
                floatingText.SetText("-SIZE", collision.transform.position);
                pickupLimiter--;
                ChangeSize(-playerSizeChange);
                player.boostMultiplier *= 1.1f;
            }
            else
            {
                floatingText.SetText("Can't shrink!", collision.transform.position);
            }
        }
        else if (collision.gameObject.CompareTag("Extra Jump"))
        {
            Destroy(collision.gameObject);
            player.SetJumpValue(player.extraJumpValue + 1);
            floatingText.SetText("+JUMP", collision.transform.position);
        }
        playerSFX.PickupSound(collision.gameObject.tag);
        }
    }



    void ChangeSize(float multiplier)
    {
        gameObject.transform.localScale += new Vector3(multiplier, multiplier, multiplier);
    }
}
