﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [Header("Settings")]
    public SkillType skillType;
    public int skillCost = 1;
    public ShopInfo infoRect;

    [Header("Settings")] public RectTransform selfRect;
    public Image soldImage;
    public Animator animator;
    public TMP_Text CostTextElement;
    private static readonly int Locked = Animator.StringToHash("Locked");

    public void Init()
    {
        if (GameManager.Current.skillz.CanDo(skillType))
        {
            CostTextElement.SetText("");
            soldImage.enabled = true;
            animator.SetBool("Locked", true);
        }
        else
        {
            CostTextElement.SetText(skillCost.ToString("N0") + " deaths");
            if (GameManager.Current.currency.CanAfford(skillCost))
            {
                animator.SetBool("locked", false);
            }
            else
            {
                animator.SetBool("Locked", true);
            }
        }
    }
    
    public void Select()
    {
        animator.SetBool("Selected", true);
        infoRect.Show();
    }

    public void Deselect()
    {
        animator.SetBool("Selected", false);
        infoRect.Hide();
    }

    public void Click()
    {
        if(GameManager.Current.currency.CanAfford(skillCost))
            Shop.Current.BuySkill(this);
    }

    public void PurchaseSucceeded()
    {
        soldImage.enabled = true;
    }
    
    public void PurchaseFailed()
    {
        Debug.Log("Did not purchase skill " + skillType.ToString());
        animator.SetTrigger("PurchaseFailed");
    }
}