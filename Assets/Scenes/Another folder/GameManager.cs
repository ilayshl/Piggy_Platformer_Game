using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
[SerializeField][Range(0, 10f)] private float timeBetweenSpawns;
[SerializeField] private GameObject fallingObject;
[SerializeField] Transform parent;
private float lastSpawnTime;
private Spawner spawner; 

private void Awake() {
    spawner = GetComponent<Spawner>();
}
    void Update()
    {
        if(Time.time > lastSpawnTime + timeBetweenSpawns)
        {
            CallSpawnObjects();
        }
    }

    private void CallSpawnObjects()
    {
        lastSpawnTime = Time.time;
        spawner.Spawn(fallingObject, RandomSpawnPos(), parent);
    }

    private Vector3 RandomSpawnPos(){

        return new Vector3(Random.Range(-8, 8), 10, 0);
    }
}
