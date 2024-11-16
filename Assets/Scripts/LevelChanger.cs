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

    void Start()
    {
        pos = transform.position;
        pickupSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<PickupSpawner>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Player")){
        if(onCooldown){return;}
            if(other.transform.position.x>transform.position.x){
                transform.position = new Vector3(pos.x+18, pos.y, pos.z);
                pos = transform.position;
                gameCamera.transform.position = new Vector3(gameCamera.transform.position.x+18, gameCamera.transform.position.y, gameCamera.transform.position.z);
                onCooldown=true;
                Invoke("FinishCooldown", 0.5f);
                pickupSpawner.levelCounter++;
            }else{
                 transform.position = new Vector3(pos.x-18, pos.y, pos.z);
                pos = transform.position;
                gameCamera.transform.position = new Vector3(gameCamera.transform.position.x-18, gameCamera.transform.position.y, gameCamera.transform.position.z);
                onCooldown=true;
                Invoke("FinishCooldown", 0.5f);
                pickupSpawner.levelCounter--;
            }
        }
    }

    void FinishCooldown() {
        onCooldown=false;
    }
}
    