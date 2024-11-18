using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] ParticleSystem jumpParticles;
    [SerializeField] ParticleSystem dashParticles;

    public void JumpParticles(Vector2 pos, Vector3 scale) {
        var particle = Instantiate(jumpParticles, pos, Quaternion.identity);
        particle.transform.localScale=scale/1.25f;
        particle.Play();
        Destroy(particle.gameObject, 1f);
    }

    public void RightDashParticles(Vector2 pos, Vector3 scale) {
        var particle = Instantiate(dashParticles, pos, Quaternion.Euler(0, 0, 90));
        particle.transform.localScale=scale/1.4f;
        particle.Play();
        Destroy(particle.gameObject, 1f);
    }

    public void LeftDashParticles(Vector2 pos, Vector3 scale) {
        var particle = Instantiate(dashParticles, pos, Quaternion.Euler(0, 0, -90));
        particle.transform.localScale=scale/1.35f;
        particle.Play();
        Destroy(particle.gameObject, 1f);
    }
}
