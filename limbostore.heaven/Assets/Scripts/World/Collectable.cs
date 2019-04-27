using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableName collectableName;

    private void Start()
    {
        if(GameManager.Current.collectables.HasCollectable(collectableName))
        {
            Destroy(gameObject);
        }
    }

    public void Collect()
    {
        GameManager.Current.collectables.AddCollectable(collectableName);
        Destroy(gameObject);
    }
}
