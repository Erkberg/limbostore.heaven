using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Current { private set; get; }
    
    public ShopItem[] shopItems;
    public Canvas selfCanvas;
    
    void Awake()
    {
        Current = this;
    }

    public void OpenShop()
    {
        selfCanvas.enabled = true;
        foreach (var item in shopItems)
        {
            item.Init();
        }
        
        shopItems[0].Select();
    }

    public void CloseShop()
    {
        foreach (var item in shopItems)
        {
            item.Deselect();
        }

        selfCanvas.enabled = false;
    }

    public void BuySkill(ShopItem item)
    {
        if (GameManager.Current.currency.Purchase(item.skillCost))
        {
            GameManager.Current.skillz.AddSkill(item.skillType);
            item.PurchaseSucceeded();
        }
        else
        {
            Debug.LogError("Can not afford this item.");
            item.PurchaseFailed();
        }
    }
}
