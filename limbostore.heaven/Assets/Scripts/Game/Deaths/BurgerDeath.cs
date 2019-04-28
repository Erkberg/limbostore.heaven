using System.Collections.Generic;
using Game;
using UnityEngine;

public class BurgerDeath : MonoBehaviour, ICustomDeath
{
    public AudioSource source;
    public AudioClip clip;
    public DeathType deathType;
    public GameObject[] burgers;
    
    List<GameObject> burgerList = new List<GameObject>();
    void Start()
    {
        foreach (var burger in burgers)
        {
            burgerList.Add(burger);
        }
    }

    public void Trigger()
    {
        if(burgerList.Count == 1)
            GameManager.Current.TriggerDeath(deathType);
        else
        {
            var burger = burgerList[Random.Range(0, burgerList.Count)];
            burgerList.Remove(burger);
            Destroy(burger);
            source.PlayOneShot(clip);
        }
    }

    public bool CanTrigger()
    {
        return true;
    }
}
