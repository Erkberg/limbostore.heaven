﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        GameManager.Current.SetPlayerLocked(true);
        selfCanvas.enabled = true;       

        foreach (var item in shopItems)
        {
            item.Init();
        }

        EventSystem.current.SetSelectedGameObject(shopItems[0].gameObject);
        shopItems[0].Select();
    }

    public void CloseShop()
    {
        foreach (var item in shopItems)
        {
            item.Deselect();
        }

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
