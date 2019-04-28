using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroOutroScreen : MonoBehaviour
{
    public enum Type { Intro, Outro }
    public Type type;

    public Canvas canvas;
    public Animator animator;
    public TMP_Text StatsText;
    
    public AudioSource audioSource;
    public bool isActive = true;
    public bool inMainMenu = true;
    
    private void Start()
    {
        if(type == Type.Intro)
            Show();
    }

    private void Update()
    {
        if (isActive && type == Type.Intro)
        {
            if (Input.anyKeyDown)
            {
                if (inMainMenu)
                {
                    animator.SetBool("MainMenu", false);                    
                }
                else
                {
                    animator.SetTrigger("Skip");
                }
            }
        } else if (isActive && type == Type.Outro)
        {
            if (Input.anyKeyDown)
            {
                isActive = false;
                animator.SetBool("MainMenu", false);
            }
        }
    }

    public void ExitMainMenu()
    {
        inMainMenu = false;
    }

    public void Show()
    {
        GameManager.Current.SetPlayerLocked(true);
        animator.SetBool("MainMenu", true);
        canvas.enabled = true;
        isActive = true;
    }

    public void SetupStatistics()
    {
        if (StatsText == null)
            return;
        StatsText.SetText(GameManager.Current.currency.ToString());
    }

    public void AnimationDone()
    {
        isActive = false;
        GameManager.Current.SetPlayerLocked(false);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Close()
    {
        canvas.enabled = false;
        Destroy(this);
    }
}
