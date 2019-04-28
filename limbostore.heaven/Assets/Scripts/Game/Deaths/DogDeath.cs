using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class DogDeath : MonoBehaviour, ICustomDeath
{
    public Puppys puppys;
    public DeathType deathType;
    
    public void Trigger()
    {
        if (!GameManager.Current.skillz.CanDo(SkillType.Sneak))
        {
            puppys.WakeUp();
            GameManager.Current.SetPlayerLocked(true);
            Invoke(nameof(TriggerDeath), 1f);            
        }
    }

    void TriggerDeath()
    {
        GameManager.Current.SetPlayerLocked(false);
        GameManager.Current.TriggerDeath(deathType);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (GameManager.Current.skillz.CanDo(SkillType.Sneak))
        {
            GameManager.Current.events.TriggerEvent(EventManager.EventType.Move);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Current.skillz.CanDo(SkillType.Sneak))
        {
            GameManager.Current.events.TriggerEvent(EventManager.EventType.Sneak);
        }
    }

    public bool CanTrigger()
    {
        return true;
    }
}
