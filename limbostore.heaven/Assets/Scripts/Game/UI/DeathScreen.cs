using System.Collections;
using System.Collections.Generic;
using Game;
using TMPro;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public Canvas canvas;

    public CanvasGroup selfGroup;

    public TMP_Text titleTextElement, descriptionTextElement;
    public AudioSource audioSource;

    public Animator animator;
    
    void Awake()
    {
    }
    
    public void DisplayDeathType(DeathType type, bool firstTimeDeath)
    {
        titleTextElement.SetText(type.title);
        descriptionTextElement.SetText(type.description + "<br><br> You were rewarded " +
           (firstTimeDeath ? +type.rewardFirstDeath : type.rewardDefault).ToString("N0") +
           " lives.");
        
        if(type.deathClip != null)
            audioSource.PlayOneShot(type.deathClip);
        
        animator.SetBool("Active", true);
    }

    public void Close()
    {
        animator.SetBool("Active", false);
    }
}
