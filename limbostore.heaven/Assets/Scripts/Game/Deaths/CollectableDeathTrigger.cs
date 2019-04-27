using System;
using Game;
using UnityEngine;

public class CollectableDeathTrigger : MonoBehaviour
{
    public DeathType deathType;

    public enum CollectableDeathType
    {
        DieIfExists, DieIfNotExists
    }

    public CollectableDeathType type = CollectableDeathType.DieIfNotExists;
    public string collectable = "";
    public void TriggerDeath()
    {
        switch (type)
        {
            case CollectableDeathType.DieIfExists:
                if(GameManager.Current.collectables.HasCollectable(collectable))
                    GameManager.Current.TriggerDeath(deathType);
                break;
            case CollectableDeathType.DieIfNotExists:
                if(!GameManager.Current.collectables.HasCollectable(collectable))
                    GameManager.Current.TriggerDeath(deathType);
                break;
        }
    }
}
