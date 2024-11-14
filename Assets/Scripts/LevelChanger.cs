using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] bool nextLevel;
    [SerializeField] GameObject gameCamera;
    PickupSpawner pickupSpawner;
    Vector3 pos;
    bool onCooldown=false;
    float cooldownTimer=0;

    void Start()
    {
        pos = transform.position;
        pickupSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<PickupSpawner>();
    }

private void Update() {
    if(onCooldown){
        cooldownTimer+=Time.deltaTime;
        if((int)cooldownTimer==2){
            onCooldown=false;
        }
    }
}
    private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Player")){
        if(onCooldown){return;}
            if(other.transform.position.x>transform.position.x){
                transform.position = new Vector3(pos.x+18, pos.y, pos.z);
                pos = transform.position;
                Debug.Log("gone right, new pos: "+pos);
                gameCamera.transform.position = new Vector3(gameCamera.transform.position.x+18, gameCamera.transform.position.y, gameCamera.transform.position.z);
                onCooldown=true;
                cooldownTimer=0;
                pickupSpawner.levelCounter++;
            }else{
                 transform.position = new Vector3(pos.x-18, pos.y, pos.z);
                pos = transform.position;
                Debug.Log("gone left, new pos: "+pos);
                gameCamera.transform.position = new Vector3(gameCamera.transform.position.x-18, gameCamera.transform.position.y, gameCamera.transform.position.z);
                onCooldown=true;
                cooldownTimer=0;
                pickupSpawner.levelCounter--;
            }
        }
    }
    
    /*private void OnTriggerExit2D(Collider2D other) {
        if(onCooldown){onCooldown=false;
        Debug.Log("reset cooldown");}
    }*/
}
    