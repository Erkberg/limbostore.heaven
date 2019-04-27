using System.Collections;
using System.Collections.Generic;
using Game;
using TMPro;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public Canvas canvas;

    public CanvasGroup selfGroup;

    public TMP_Text titleTextElement, descriptionTextElement, rewardText;
    public AudioSource audioSource;

    public Animator animator;

    private bool isActive = false;
    
    private void Update()
    {
        if (isActive)
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("finished");
                Close();
                GameManager.Current.Restart(2f);
            }
        }
    }

    public void DisplayDeathType(DeathType type, bool firstTimeDeath)
    {
        titleTextElement.SetText(type.title);
        descriptionTextElement.SetText(type.description);
        rewardText.SetText((firstTimeDeath ? +type.rewardFirstDeath : type.rewardDefault).ToString("N0"));
        
        if(type.deathClip != null)
            audioSource.PlayOneShot(type.deathClip);
        
        animator.SetBool("Active", true);
        Invoke(nameof(ShowText), type.textDelay);
    }

    void ShowText()
    {
        isActive = true;
        animator.SetBool("ShowText", true);
    }

    public void Close()
    {
        isActive = false;
        animator.SetBool("ShowText", false);
        animator.SetBool("Active", false);
    }
}
