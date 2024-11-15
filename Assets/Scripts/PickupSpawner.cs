using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PickupSpawner : MonoBehaviour
{
    public int levelCounter = 1;
    [SerializeField] GameObject[] pickupList;
    float timer = 0;
    int randomizer;
    PlayerMovement player;
    Vector2 spawnArea;
    void Start()
    {
        SetRandomizer();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        spawnArea = new Vector2(8 * levelCounter - 16 - (2 * levelCounter), 8 * levelCounter + (2 * levelCounter));
    }

    void Update()
    {
        if (player.gamePaused) { return; }
        timer += Time.deltaTime;
        if ((int)timer % randomizer == 0 && (int)timer != 0)
        {
            SpawnPickup();
            SetRandomizer();
            Debug.Log("randomized for " + randomizer + " seconds.");
            timer = 0;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnPickup();
        }
    }

    void SpawnPickup()
    {
        if (levelCounter == 1)
        {
            Instantiate(pickupList[0], new Vector2(Random.Range(-8, 8), 6), Quaternion.identity);
        }
        if (levelCounter == 2)
        {
            Instantiate(pickupList[1], new Vector2(Random.Range(10, 26), 6), Quaternion.identity);
        }
        if (levelCounter == 3)
        {
            Instantiate(pickupList[Random.Range(0, pickupList.Length)], new Vector2(Random.Range(28, 44), 6), Quaternion.identity);
        }
    }

    void SetRandomizer()
    {
        randomizer = Random.Range(3, 8);
    }
}
