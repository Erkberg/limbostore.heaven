using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class DeathByDoingNothing : MonoBehaviour
{
    public float timeToTrigger = 15f;
    public DeathType deathType;

    [SerializeField]
    private float timer = 0f;
    
    void Update()
    {
        if (GameManager.Current.PlayerLocked)
            return;

        Debug.Log(Mathf.Abs(Input.GetAxis(InputStrings.HorizontalAxis)));
        
        if (Input.anyKey)
        {
            timer = 0f;
        } else if (Mathf.Abs(Input.GetAxis(InputStrings.HorizontalAxis)) > 0.05f || Mathf.Abs(Input.GetAxis(InputStrings.VerticalAxis)) > 0.05f)
        {
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (timer > timeToTrigger)
        {
            this.enabled = false;
            GameManager.Current.TriggerDeath(deathType);
        }
    }
}
