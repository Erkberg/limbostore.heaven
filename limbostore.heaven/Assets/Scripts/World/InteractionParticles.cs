using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionParticles : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem[] particles;
    [SerializeField]
    private ParticleSystem particlesUnavailable;

    public void Play()
    {
        foreach (ParticleSystem particle in particles)
        {
            particle.Play();
        }
    }

    public void PlayUnavailable()
    {
        particlesUnavailable.Play();
    }

    public void Stop()
    {        
        foreach (ParticleSystem particle in particles)
        {
            particle.Stop();
        }

        particlesUnavailable.Stop();
    }
}
