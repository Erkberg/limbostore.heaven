using UnityEngine.Events;

public class EventManager
{
    public enum EventType
    {
        None, NewGame, GameIsStarting, Death, NewSkill, PauseGame, ResumeGame
    }

    public EventType lastEvent = EventType.None;

    public UnityEvent NewGame = new UnityEvent();
    public UnityEvent GameIsStarting = new UnityEvent();
    public UnityEvent PauseGame = new UnityEvent();
    public UnityEvent ResumeGame = new UnityEvent();
    public UnityEvent Death = new UnityEvent();
    public UnityEvent NewSkill = new UnityEvent();
    
    public void TriggerEvent(EventType eventType)
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
        }
    }
}
