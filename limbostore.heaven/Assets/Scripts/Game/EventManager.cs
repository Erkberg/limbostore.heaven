﻿using System;
using UnityEngine.Events;

public class EventManager
{
    public enum EventType
    {
        None, NewGame, GameIsStarting, Death, NewSkill, PauseGame, ResumeGame, NewCollectable, Sneak, Move
    }

    public EventType lastEvent = EventType.None;

    public UnityEvent NewGame = new UnityEvent();
    public UnityEvent GameIsStarting = new UnityEvent();
    public UnityEvent PauseGame = new UnityEvent();
    public UnityEvent ResumeGame = new UnityEvent();
    public UnityEvent Death = new UnityEvent();
    public UnityEvent NewSkill = new UnityEvent();
    public UnityEvent NewCollectable = new UnityEvent();
    
    public UnityEvent Sneak = new UnityEvent();
    public UnityEvent StopSneak = new UnityEvent();

    public EventManager()
    {
        
    }
    
    public void TriggerEvent(EventType eventType, string value = "")
    {
        switch (eventType)
        {
            case EventType.None:
                break;
            case EventType.NewGame:
                NewGame.Invoke();
                break;
            case EventType.Death:
                Death.Invoke();
                break;
            case EventType.NewSkill:
                NewSkill.Invoke();
                break;
            case EventType.GameIsStarting:
                GameIsStarting.Invoke();
                break;
            case EventType.PauseGame:
                PauseGame.Invoke();
                break;
            case EventType.ResumeGame:
                ResumeGame.Invoke();
                break;
            case EventType.NewCollectable:
                NewCollectable.Invoke();
                break;
            case EventType.Sneak:
                Sneak.Invoke();
                break;
            case EventType.Move:
                StopSneak.Invoke();
                break;
        }
    }
}
