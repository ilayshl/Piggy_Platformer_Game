using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool onFloor;
    public float boostMultiplier=1;
    public int extraJumpValue;
    public bool gamePaused = true;
    [SerializeField] float verticalForce = 25;
    [SerializeField] float horizontalForce = 30;
    [SerializeField] float jumpForce = 50;
    Rigidbody2D rb;
    SpriteRenderer sr;
    PlayerSFX playerSFX;
    ParticleSpawner particleSpawner;
    Vector2 sideBoost;
    Vector2 jumpBoost;
    int extraJump;

    void Start()
    {
        gamePaused = true;
       rb = gameObject.GetComponent<Rigidbody2D>();
       sr = gameObject.GetComponent<SpriteRenderer>();
        playerSFX= gameObject.GetComponent<PlayerSFX>();
        particleSpawner=GameObject.FindGameObjectWithTag("Spawner").GetComponent<ParticleSpawner>();
       sideBoost = new Vector2(horizontalForce, verticalForce);
       jumpBoost = new Vector2(0, jumpForce);
        extraJump=extraJumpValue;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))gamePaused=!gamePaused;
        if(gamePaused){ return; }
    if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
      if(extraJump>0){
        if(onFloor==false) rb.velocity=rb.velocity/2;
    rb.AddForce(new Vector2(-horizontalForce, verticalForce)*boostMultiplier, ForceMode2D.Impulse);
    onFloor=false;
    sr.flipX = false;
                sr.color=Color.yellow;
                playerSFX.JumpSound(extraJump);
                extraJump--;
                if(extraJump==0) {
                    sr.color=Color.red;
                }
            } else {
                playerSFX.JumpSound(extraJump);
            }
        }
    if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
      if(extraJump>0) {
        if(onFloor==false) rb.velocity=rb.velocity/2;
    rb.AddForce(sideBoost*boostMultiplier, ForceMode2D.Impulse);
    onFloor=false;
    sr.flipX = true;
                sr.color=Color.yellow;
                playerSFX.JumpSound(extraJump);
                extraJump--;
                if(extraJump==0) {
                    sr.color=Color.red;
                }
            } else {
                playerSFX.JumpSound(extraJump);
            }
        }
    if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)){
      if(extraJump>0) {
        if(onFloor==false) rb.velocity=rb.velocity/2;
    rb.AddForce(jumpBoost*boostMultiplier, ForceMode2D.Impulse);
    onFloor=false;
                sr.color=Color.yellow;
                playerSFX.JumpSound(extraJump);
                extraJump--;
                particleSpawner.JumpParticles(new Vector2(transform.position.x, GetComponent<CapsuleCollider2D>().bounds.min.y), transform.localScale);
                if(extraJump==0) {
                    sr.color=Color.red;
                }
            } else {
                playerSFX.JumpSound(extraJump);
            }
            
        }
    }

   public void ResetJump() {
        onFloor=true;
        extraJump=extraJumpValue;
        sr.color=Color.white;
    }

public void SetJumpValue(int amount){
    extraJumpValue=amount;
    extraJump=extraJumpValue;
    sr.color = Color.white;
}

}
