using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionParticles : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem[] particles;

    public void Play()
    {
        foreach (ParticleSystem particle in particles)
        {
            particle.Play();
        }
    }

    public void Stop()
    {
        
        foreach (ParticleSystem particle in particles)
        {
            particle.Stop();
        }
    }
}
