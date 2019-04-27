using UnityEngine.Events;

public class EventManager
{
    public enum EventType
    {
        None, NewGame, GameIsStarting, Death, NewSkill, PauseGame, ResumeGame, NewCollectable
    }

    public EventType lastEvent = EventType.None;

    public UnityEvent NewGame = new UnityEvent();
    public UnityEvent GameIsStarting = new UnityEvent();
    public UnityEvent PauseGame = new UnityEvent();
    public UnityEvent ResumeGame = new UnityEvent();
    public UnityEvent Death = new UnityEvent();
    public UnityEvent<string> NewSkill;
    public UnityEvent<string> NewCollectable;

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
                NewSkill.Invoke(value);
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
                NewCollectable.Invoke(value);
                break;
        }
    }
}
