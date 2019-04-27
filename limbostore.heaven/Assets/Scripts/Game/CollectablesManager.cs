using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager
{
    private List<string> collectables = new List<string>();
    
    public bool HasCollectable(string collectable)
    {
        return collectables.Contains(collectable);
    }

    public void Receive(string collectable)
    {
        if (!collectables.Contains(collectable))
        {
            collectables.Add(collectable);
            GameManager.Current.events.TriggerEvent(EventManager.EventType.NewCollectable, collectable);
        }
    }
}
