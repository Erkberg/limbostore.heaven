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

    public void TriggerDeath()
    {
        switch (type)
        {
            case CollectableDeathType.DieIfExists:
                GameManager.Current.TriggerDeath(deathType);
                break;
            case CollectableDeathType.DieIfNotExists:
                GameManager.Current.TriggerDeath(deathType);
                break;
        }
    }
}
