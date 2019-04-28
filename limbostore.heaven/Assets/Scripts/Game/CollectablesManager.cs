using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager
{
    public bool hasAllCollectables = false;
    
    private List<CollectableName> collectables = new List<CollectableName>();
    
    public bool HasCollectable(CollectableName collectableName)
    {
        if (collectableName == CollectableName.None)
            return true;
        else
            return collectables.Contains(collectableName) || hasAllCollectables;
    }

    public void AddCollectable(CollectableName collectableName)
    {
        if (!collectables.Contains(collectableName))
        {
            Debug.Log("just collected " + collectableName.ToString());
            collectables.Add(collectableName);
            GameManager.Current.events.TriggerEvent(EventManager.EventType.NewCollectable, collectableName.ToString());
        }
    }
    
    #if UNITY_EDITOR

    public void PrintEditor()
    {
        foreach (var item in collectables)
        {
            GUILayout.Label(item.ToString());
        }
    }
    #endif
}

public enum CollectableName
{
    None,
    CheesyMovie,
    ScaryMovie,
    FunnyMovie
}