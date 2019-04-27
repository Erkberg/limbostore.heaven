using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private InteractionArea currentInteractionArea;

    private void Update()
    {
        if(Input.GetButtonDown(InputStrings.InteractButton))
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
