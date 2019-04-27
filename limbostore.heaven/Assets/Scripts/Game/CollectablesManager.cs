using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager
{
    #if UNITY_EDITOR
    public bool hasAllCollectables = false;
    #endif
    
    private List<string> collectables = new List<string>();
    
    public bool HasCollectable(string collectable)
    {
        return collectables.Contains(collectable) || hasAllCollectables;
    }

    public void AddCollectable(string collectable)
    {
        if (!collectables.Contains(collectable))
        {
            Debug.Log("just collected " + collectable);
            collectables.Add(collectable);
            GameManager.Current.events.TriggerEvent(EventManager.EventType.NewCollectable, collectable);
        }
    }
}
