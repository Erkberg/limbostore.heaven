using UnityEngine;

public class VideoMovieDeath : MonoBehaviour, ICustomDeath
{
    public BaseDeathTrigger CheesyLeft, FunnyRight, ScaryOben;
    public SpriteRenderer Left, Right, Top;

    public Color NormalColor = Color.white, HighlightColor = Color.red;
    
    public bool isActive = false;

    private void Start()
    {
        CheesyLeft.gameObject.SetActive(false);
        FunnyRight.gameObject.SetActive(false);
        ScaryOben.gameObject.SetActive(false);
    }

    public void Trigger()
    {
        if (isActive)
            return;
        Debug.Log("Starting movie death");
        isActive = true;
        GameManager.Current.SetPlayerLocked(true);
        EnableVideos();
    }

    public bool CanTrigger()
    {
        return GameManager.Current.collectables.HasCollectable(CollectableName.FunnyMovie) ||
               GameManager.Current.collectables.HasCollectable(CollectableName.CheesyMovie) ||
               GameManager.Current.collectables.HasCollectable(CollectableName.ScaryMovie);
    }

    void EnableVideos()
    {
        Left.color = NormalColor;
        Right.color = NormalColor;
        Top.color = NormalColor;
        CheesyLeft.gameObject.SetActive(GameManager.Current.collectables.HasCollectable(CollectableName.CheesyMovie));
        FunnyRight.gameObject.SetActive(GameManager.Current.collectables.HasCollectable(CollectableName.FunnyMovie));
        ScaryOben.gameObject.SetActive(GameManager.Current.collectables.HasCollectable(CollectableName.ScaryMovie));
    }

    void DisableVideoScreen()
    {
        isActive = false;
        CheesyLeft.gameObject.SetActive(false);
        FunnyRight.gameObject.SetActive(false);
        ScaryOben.gameObject.SetActive(false);
        GameManager.Current.SetPlayerLocked(false);
    }

    private void Update()
    {
        if (isActive)
        {
            if (Input.GetButtonDown(InputStrings.SneakButton))
            {
                DisableVideoScreen();
                return;
            }

            Vector2 pos =
                new Vector2(Input.GetAxis(InputStrings.HorizontalAxis), Input.GetAxis(InputStrings.VerticalAxis))
                    .normalized;

            if (pos.y > 0.3f && pos.y > Mathf.Abs(pos.x))
            {
                Left.color = NormalColor;
                Right.color = NormalColor;
                Top.color = HighlightColor;
                if (Input.GetButtonDown(InputStrings.InteractButton))
                {
                    if (GameManager.Current.collectables.HasCollectable(CollectableName.ScaryMovie))
                    {
                        DisableVideoScreen();
                        ScaryOben.TriggerDeath();
                    }
                }
            }
            else if (pos.x > 0.3f)
            {
                Left.color = NormalColor;
                Right.color = HighlightColor;
                Top.color = NormalColor;
                if (Input.GetButtonDown(InputStrings.InteractButton))
                {
                    if (GameManager.Current.collectables.HasCollectable(CollectableName.FunnyMovie))
                    {
                        DisableVideoScreen();
                        FunnyRight.TriggerDeath();
                    }
                }
            }
            else if (pos.x < -0.3f)
            {
                Left.color = HighlightColor;
                Right.color = NormalColor;
                Top.color = NormalColor;
                if (Input.GetButtonDown(InputStrings.InteractButton))
                {
                    if (GameManager.Current.collectables.HasCollectable(CollectableName.CheesyMovie))
                    {
                        DisableVideoScreen();
                        CheesyLeft.TriggerDeath();
                    }
                }
            }
            else
            {
                Left.color = NormalColor;
                Right.color = NormalColor;
                Top.color = NormalColor;
            }
        }
    }
}
