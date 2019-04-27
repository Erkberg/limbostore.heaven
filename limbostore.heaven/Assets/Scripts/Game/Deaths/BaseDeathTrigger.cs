using Game;
using UnityEngine;

public class BaseDeathTrigger : MonoBehaviour
{
    public DeathType deathType;

    public void TriggerDeath()
    {
        GameManager.Current.TriggerDeath(deathType);
    }
}
