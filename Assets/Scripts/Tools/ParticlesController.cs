using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particlesLoop;
    [SerializeField] private ParticleSystem _particlesOnDestroy;

    private void OnDestroy()
    {
        if (_particlesLoop != null)
            DestroyLoopParticles(_particlesLoop);

        if (_particlesOnDestroy != null)
            PlayParticlesOnDestroy(_particlesOnDestroy);
    }

    private void DestroyLoopParticles(ParticleSystem particles)
    {
        particles.transform.SetParent(null);
        particles.Stop();
        Destroy(particles.gameObject, particles.main.startLifetime.constantMax);
    }

    private void PlayParticlesOnDestroy(ParticleSystem particles)
    {
        particles.transform.SetParent(null);
        particles.Play();
    }
}
