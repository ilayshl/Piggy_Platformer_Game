using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    float timer = 0;
    int randomizer;
    [SerializeField] GameObject[] pickupList;
    void Start()
    {
        SetRandomizer();
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if((int)timer%randomizer==0 && (int)timer!=0) {
            SpawnPickup();
            SetRandomizer();
            Debug.Log("randomized for "+randomizer+" seconds.");
            timer=0;
        }
    }

    void SpawnPickup() {
        Instantiate(pickupList[Random.Range(0, pickupList.Length)], new Vector2(Random.Range(-8, 8), 9), new Quaternion());
    }

    void SetRandomizer() {
        randomizer=Random.Range(5, 10);
    }
}
