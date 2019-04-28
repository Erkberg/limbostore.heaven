using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    public enum InteractionType
    {
        OnEnter,
        OnInteract
    }

    public enum SequenceType
    {
        SuddenDeath,
        SuddenDeathSkill,
        SuddenDeathCollectable,
        Collectable,
        AnimationThenDeath,
        ChangeScene,
        OpenShop,
        CustomDeath
    }

    public InteractionType interactionType;
    public SequenceType sequenceType;
    public InteractionParticles particles;

    private PlayerInteraction playerInteraction;

    public void TriggerInteraction()
    {
        particles.Stop();
        switch (sequenceType)
        {
            case SequenceType.SuddenDeath:
                BaseDeathTrigger baseDeathTrigger = GetComponent<BaseDeathTrigger>();
                baseDeathTrigger.TriggerDeath();
                break;
            case SequenceType.SuddenDeathSkill:
                SkillDeathTrigger skillDeathTrigger = GetComponent<SkillDeathTrigger>();
                skillDeathTrigger.TriggerDeath();
                break;
            case SequenceType.SuddenDeathCollectable:
                CollectableDeathTrigger collectableDeathTrigger = GetComponent<CollectableDeathTrigger>();
                collectableDeathTrigger.TriggerDeath();
                break;

            case SequenceType.Collectable:
                Collectable collectable = GetComponent<Collectable>();
                collectable.Collect();
                break;

            case SequenceType.AnimationThenDeath:

                break;

            case SequenceType.ChangeScene:
                ChangeLevel changleLevel = GetComponent<ChangeLevel>();
                changleLevel.LoadLevel();
                break;

            case SequenceType.OpenShop:
                Shop.Current.OpenShop();
                break;
            case SequenceType.CustomDeath:
                GetComponent<ICustomDeath>().Trigger();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Tags.PlayerTag))
        {
            particles.Play();
            CheckPlayerInteractionRef(collision);

            if(interactionType == InteractionType.OnEnter)
            {
                TriggerInteraction();
            }
            else
            {
                playerInteraction.OnEnterInteractionArea(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(Tags.PlayerTag))
        {
            particles.Stop();
            CheckPlayerInteractionRef(collision);
            playerInteraction.OnExitInteractionArea(this);
        }
    }

    private void CheckPlayerInteractionRef(Collider2D collision)
    {
        if(!playerInteraction)
        {
            playerInteraction = collision.GetComponent<PlayerInteraction>();
        }
    }
}

