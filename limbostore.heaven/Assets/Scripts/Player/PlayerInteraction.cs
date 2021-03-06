﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private InteractionArea currentInteractionArea;

    private void Update()
    {
        if (GameManager.Current.PlayerLocked)
            return;
        if(Input.GetButtonDown(InputStrings.InteractButton) && !GameManager.Current.PlayerLocked)
        {
            if(currentInteractionArea)
            {
                currentInteractionArea.TriggerInteraction();
            }
        }
    }

    public void OnEnterInteractionArea(InteractionArea area)
    {
        currentInteractionArea = area;
        Highlight();
    }

    public void OnExitInteractionArea(InteractionArea area)
    {
        if(currentInteractionArea == area)
        {
            currentInteractionArea = null;
            Dehighlight();
        }
    }

    private void Highlight()
    {

    }

    private void Dehighlight()
    {

    }
}
