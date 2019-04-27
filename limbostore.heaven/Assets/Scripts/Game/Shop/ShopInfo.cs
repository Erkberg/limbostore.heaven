using UnityEngine;

public class ShopInfo : MonoBehaviour
{
    public CanvasGroup selfGroup;

    public void Show()
    {
        selfGroup.alpha = 1f;
    }

    public void Hide()
    {
        selfGroup.alpha = 0f;
    }
}
