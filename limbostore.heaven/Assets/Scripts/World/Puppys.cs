using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppys : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] particles;
    [SerializeField] private Animator animator;

    public void WakeUp()
    {
        foreach (ParticleSystem particle in particles)
        {
            particle.Stop();
        }
        
        animator.SetTrigger("wakeUp");
    }
}
