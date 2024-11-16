using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PickupSpawner : MonoBehaviour
{
    public int levelCounter = 0;
    [SerializeField] GameObject[] pickupList;
    PlayerMovement player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (player.gamePaused) { return; }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ForceSpawnPickup();
        }
    }

    public void SpawnPickup()
    {
        if(!player.gamePaused)
            {
        if (levelCounter == 1)
        {
            Instantiate(pickupList[0], new Vector2(Random.Range(10, 26), 6), Quaternion.identity);
        }
        if (levelCounter == 2)
        {
            Instantiate(pickupList[1], new Vector2(Random.Range(28, 44), 6), Quaternion.identity);
        }
        if (levelCounter == 3)
        {
            Instantiate(pickupList[Random.Range(0, pickupList.Length)], new Vector2(Random.Range(46, 62), 6), Quaternion.identity);
        }
        }
        Invoke("SpawnPickup", Random.Range(3, 8));
    }

    void ForceSpawnPickup() {
        if(!player.gamePaused) {
            if(levelCounter==1) {
                Instantiate(pickupList[0], new Vector2(Random.Range(10, 26), 6), Quaternion.identity);
            }
            if(levelCounter==2) {
                Instantiate(pickupList[1], new Vector2(Random.Range(28, 44), 6), Quaternion.identity);
            }
            if(levelCounter==3) {
                Instantiate(pickupList[Random.Range(0, pickupList.Length)], new Vector2(Random.Range(46, 62), 6), Quaternion.identity);
            }
        }
    }
}
