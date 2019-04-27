using System;
using Game;
using UnityEngine;

public class SkillDeathTrigger : MonoBehaviour
{
    public DeathType deathType;

    public enum SkillDeathType
    {
        DieIfExists, DieIfNotExists
    }

    public SkillDeathType type = SkillDeathType.DieIfNotExists;
    public SkillType skill = SkillType.Open;
    public void TriggerDeath()
    {
        switch (type)
        {
            case SkillDeathType.DieIfExists:
                if(GameManager.Current.skillz.CanDo(skill))
                    GameManager.Current.TriggerDeath(deathType);
                break;
            case SkillDeathType.DieIfNotExists:
                if(!GameManager.Current.skillz.CanDo(skill))
                    GameManager.Current.TriggerDeath(deathType);
                break;
        }
    }
}
