using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop Current { private set; get; }

    public AudioSource source;
    public AudioClip open, close, buy, swipe, failed;

    public ShopItem[] shopItems;
    public Canvas selfCanvas;
    
    void Awake()
    {
        Current = this;
    }

    public void OpenShop()
    {
        GameManager.Current.SetPlayerLocked(true);
        selfCanvas.enabled = true;       

        foreach (var item in shopItems)
        {
            item.Init();
        }

        EventSystem.current.SetSelectedGameObject(shopItems[0].gameObject);
        shopItems[0].Select();
        source.PlayOneShot(open);
    }

    public void CloseShop()
    {
        foreach (var item in shopItems)
        {
            item.Deselect();
        }
        
        source.PlayOneShot(close);
        
        selfCanvas.enabled = false;
        EventSystem.current.SetSelectedGameObject(null);

        GameManager.Current.SetPlayerLocked(false);
    }

    private void Update()
    {
        if (!selfCanvas.enabled)
            return;

        // Check close shop
        if (Input.GetButtonDown(InputStrings.SneakButton))
        {
            CloseShop();
        }

        GameObject obj = EventSystem.current.currentSelectedGameObject;
        if (obj == null)
            return;
        
        ShopItem item = obj.GetComponent<ShopItem>();
        if (item == null)
            return;

        if (item.isSelected)
            return;

        source.PlayOneShot(swipe);
        
        foreach (var other in shopItems)
        {
            if(other == item)
                item.Select();
            else
                other.Deselect();
        }
    }

    public void BuySkill(ShopItem item)
    {
        if (GameManager.Current.currency.Purchase(item.skillCost))
        {
            source.PlayOneShot(buy);
            GameManager.Current.skillz.AddSkill(item.skillType);
            item.PurchaseSucceeded();
        }
        else
        {
            source.PlayOneShot(failed);
            Debug.Log("Can not afford this item.");
            item.PurchaseFailed();
        }
    }
}
