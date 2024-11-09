using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool onFloor;

    [SerializeField] int moveSpeed = 10;
    [SerializeField] float verticalForce = 20;
    [SerializeField] float horizontalForce = 38;
    [SerializeField] float jumpForce = 40;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Vector2 sideBoost;
    Vector2 jumpBoost;

    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
       sr = gameObject.GetComponent<SpriteRenderer>();
       sideBoost = new Vector2(verticalForce, horizontalForce);
       jumpBoost = new Vector2(0, jumpForce);
    }

    //idea: what if it's a sliding platform and the player can hop small distances (go side but a bit up) and slide
    void Update()
    {
    if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
      if(onFloor){
    Debug.Log("go left");
    rb.AddForce(new Vector2(-verticalForce, horizontalForce), ForceMode2D.Impulse);
    onFloor=false;
    sr.flipX = false;
      }
 }
    if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
      if(onFloor){
    Debug.Log("go right");
    rb.AddForce(sideBoost, ForceMode2D.Impulse);
    onFloor=false;
    sr.flipX = true;
            }
 }
    if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)){
      if(onFloor){
    Debug.Log("jump");
    rb.AddForce(jumpBoost, ForceMode2D.Impulse);
    onFloor=false;
          }
 }
    if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
    Debug.Log("go down");
 }
    }

   private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.CompareTag("Ground") && onFloor==false){
         onFloor=true;
      }
   }

}
