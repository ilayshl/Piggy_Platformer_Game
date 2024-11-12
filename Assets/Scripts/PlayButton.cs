using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] GameObject gameCamera;
    PlayerMovement player;

    float timer;
    bool timerActive=false;
    bool startSoundPlaying = false;
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update() {
        if(timerActive) {
            timer+=Time.deltaTime;
            if((int)timer==2 && startSoundPlaying==false) {
                player.GetComponent<PlayerSFX>().StartSound();
                startSoundPlaying = true;
            }
            if((int)timer==3) {
                player.gamePaused=false;
            }
    }
    }

    private void OnMouseDown() {
        gameCamera.GetComponent<Animation>().Play();
        Destroy(gameObject, 5f);
        timerActive=true;
    }
}
