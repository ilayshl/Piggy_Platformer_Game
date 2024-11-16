using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] GameObject gameCamera;
    PlayerMovement player;

    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        gameCamera.transform.position = new Vector3(0, 10, -10);
    }

    void PlaySound() {
        if(!player.GetComponent<AudioSource>().isPlaying) {
            player.GetComponent<PlayerSFX>().StartSound();
        }
        }

    void GameStart() {
        player.gamePaused=false;
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<PickupSpawner>().SpawnPickup();
    }

    private void OnMouseDown() {
        gameCamera.GetComponent<Animation>().Play();
        Destroy(gameObject, 5f);
        Invoke("PlaySound", 2f);
        Invoke("GameStart", 3f);
    }
}
