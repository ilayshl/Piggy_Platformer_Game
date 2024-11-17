using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] ParticleSystem jumpParticles;
    [SerializeField] ParticleSystem leftDashParticles;
    [SerializeField] ParticleSystem rightDashParticles;

    public void JumpParticles(Vector2 pos, Vector3 scale) {
        var particle = Instantiate(jumpParticles, pos, Quaternion.identity);
        particle.transform.localScale=scale/1.25f;
        particle.Play();
        Destroy(particle.gameObject, 1f);
    }
}
