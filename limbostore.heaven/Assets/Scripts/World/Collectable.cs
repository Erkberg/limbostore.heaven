using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string id;

    private void Start()
    {
        if(GameManager.Current.collectables.HasCollectable(id))
        {
            Destroy(gameObject);
        }
    }

    public void Collect()
    {
        GameManager.Current.collectables.AddCollectable(id);
        Destroy(gameObject);
    }
}
