using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborMusic : MonoBehaviour
{
    public AudioSource loudSource, quietSource;

    void Start()
    {
        if (GameManager.Current.skillz.CanDo(SkillType.Ohrstoepsel))
        {
            quietSource.Play();
        }
        else
        {
            loudSource.Play();
        }
    }

    private void Update()
    {
        if (GameManager.Current.PlayerLocked)
        {
            this.enabled = false;
            quietSource.Stop();
            loudSource.Stop();
        }
    }
}
