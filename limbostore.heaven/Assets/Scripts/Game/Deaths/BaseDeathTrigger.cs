using Game;
using UnityEngine;

public class BaseDeathTrigger : MonoBehaviour
{
    public DeathType deathType;
    public bool triggerOnce = false;
    private bool wasTriggered = false;
    
    public void TriggerDeath()
    {
        if (triggerOnce && wasTriggered)
        {
            wasTriggered = true;
            GameManager.Current.TriggerDeath(deathType);    
        }
    }
}
