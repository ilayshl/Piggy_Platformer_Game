using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] pickupList;
    float timer = 0;
    int randomizer;
    PlayerMovement player;
    void Start()
    {
        SetRandomizer();
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(player.gamePaused){ return; }
        timer+=Time.deltaTime;
        if((int)timer%randomizer==0 && (int)timer!=0) {
            SpawnPickup();
            SetRandomizer();
            Debug.Log("randomized for "+randomizer+" seconds.");
            timer=0;
        }


        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            Instantiate(pickupList[0], new Vector2(Random.Range(-8, 8), 6), Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            Instantiate(pickupList[1], new Vector2(Random.Range(-8, 8), 6), Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            Instantiate(pickupList[2], new Vector2(Random.Range(-8, 8), 6), Quaternion.identity);
        }
    }

    void SpawnPickup() {
        Instantiate(pickupList[Random.Range(0, pickupList.Length)], new Vector2(Random.Range(-8, 8), 6), Quaternion.identity);
    }

    void SetRandomizer() {
        randomizer=Random.Range(5, 10);
    }
}
