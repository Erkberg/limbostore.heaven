using System.Collections;
using System.Collections.Generic;
using Game;
using TMPro;
using UnityEngine;

public class IntroOutroScreen : MonoBehaviour
{
    public enum Type { Intro, Outro }
    public Type type;

    public Canvas canvas;
    public CanvasGroup selfGroup;

    public TMP_Text[] blocks;
    public AudioSource audioSource;

    private bool isActive = false;
    private bool skip = false;
    private float waitTimePerText = 4f;

    private void Start()
    {
        foreach (TMP_Text block in blocks)
        {
            block.alpha = 0f;
        }

        if(type == Type.Intro)
        {
            PlayBlocks();
        }
    }

    private void Update()
    {
        if (isActive)
        {
            if (Input.anyKeyDown)
            {
                skip = true;
            }
        }
    }

    public void PlayBlocks()
    {
        StartCoroutine(PlayBlocksSequence());
    }

    public IEnumerator PlayBlocksSequence()
    {
        GameManager.Current.SetPlayerLocked(true);
        ShowText();
        float counter = 0f;

        foreach(TMP_Text block in blocks)
        {
            block.alpha = 1f;
            counter = 0f;

            while (counter < waitTimePerText)
            {
                counter += Time.deltaTime;
                if(skip)
                {
                    skip = false;
                    break;
                }
                yield return null;
            }
        }

        yield return new WaitUntil(() => skip);
        Close();
        GameManager.Current.SetPlayerLocked(false);
    }

    public void DisplayDeathType(DeathType type, bool firstTimeDeath)
    {
        
        if(type.deathClip != null)
            audioSource.PlayOneShot(type.deathClip);
        
        Invoke(nameof(ShowText), type.textDelay);
    }

    void ShowText()
    {
        canvas.enabled = true;
        isActive = true;
    }

    public void Close()
    {
        canvas.enabled = false;
        isActive = false;
    }
}
