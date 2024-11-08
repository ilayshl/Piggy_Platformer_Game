using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int jumpForce = 10;
    [SerializeField] int moveSpeed = 10;
    Rigidbody2D rb;
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();

    }

    //idea: what if it's a sliding platform and the player can hop small distances (go side but a bit up) and slide
    void Update()
    {
    if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
    Debug.Log("go left");
 }
    if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
    Debug.Log("go right");
 }
    if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)){
    Debug.Log("jump");
 }
    if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
    Debug.Log("go left");
 }
    }
}
