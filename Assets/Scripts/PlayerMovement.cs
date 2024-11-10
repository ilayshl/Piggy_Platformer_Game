using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool onFloor;
    public float boostMultiplier=1;
    public int extraJumpValue;

    [SerializeField] int moveSpeed = 10;
    [SerializeField] float verticalForce = 25;
    [SerializeField] float horizontalForce = 30;
    [SerializeField] float jumpForce = 50;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Vector2 sideBoost;
    Vector2 jumpBoost;
    int extraJump;

    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
       sr = gameObject.GetComponent<SpriteRenderer>();
       sideBoost = new Vector2(horizontalForce, verticalForce);
       jumpBoost = new Vector2(0, jumpForce);
        extraJump=extraJumpValue;
    }

    //idea: what if it's a sliding platform and the player can hop small distances (go side but a bit up) and slide
    void Update()
    {
    if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
      if(extraJump>0){
        if(onFloor==false) rb.velocity=rb.velocity/2;
    rb.AddForce(new Vector2(-horizontalForce, verticalForce)*boostMultiplier, ForceMode2D.Impulse);
    onFloor=false;
    sr.flipX = false;
                sr.color=Color.yellow;
                extraJump--;
            }if(extraJump==0){
                sr.color = Color.red;
            }
 }
    if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
      if(extraJump>0) {
        if(onFloor==false) rb.velocity=rb.velocity/2;
    rb.AddForce(sideBoost*boostMultiplier, ForceMode2D.Impulse);
    onFloor=false;
    sr.flipX = true;
                sr.color=Color.yellow;
                extraJump--;
            } if(extraJump==0) {
                sr.color=Color.red;
            }
        }
    if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)){
      if(extraJump>0) {
        if(onFloor==false) rb.velocity=rb.velocity/2;
    rb.AddForce(jumpBoost*boostMultiplier, ForceMode2D.Impulse);
    onFloor=false;
                sr.color=Color.yellow;
                extraJump--;
            }if(extraJump==0) {
                sr.color=Color.red;
            }
        }
    if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){

 }
    }

   private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.CompareTag("Ground") && onFloor==false){
         onFloor=true;
         extraJump=extraJumpValue;
            sr.color = Color.white;
      }
   }

public void ExtraJumpChange(int amount){
    extraJumpValue=amount;
    extraJump=extraJumpValue;
    sr.color = Color.white;
}

}
