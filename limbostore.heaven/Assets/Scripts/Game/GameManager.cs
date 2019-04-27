using Game;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CurrencyManager currencyManager = new CurrencyManager();
    private EventManager eventManager = new EventManager();
    private CollectablesManager collectablesManager = new CollectablesManager();
    private SkillManager skillzManager = new SkillManager();
    
    public CurrencyManager currency => currencyManager;
    public EventManager events => eventManager;
    public CollectablesManager collectables => collectablesManager;
    public SkillManager skillz => skillzManager;

    public static GameManager Current { private set; get; }
    
    void Awake()
    {
        Current = this;
    }

}
