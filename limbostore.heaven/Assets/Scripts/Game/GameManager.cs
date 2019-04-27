using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CurrencyManager currencyManager = new CurrencyManager();
    private EventManager eventManager = new EventManager();
    private CollectablesManager collectablesManager = new CollectablesManager();
    
    public CurrencyManager currency => currencyManager;
    public EventManager events => eventManager;
    public CollectablesManager collectables => collectablesManager;

    public static GameManager Current { private set; get; }
    
    void Awake()
    {
        Current = this;
    }

    void Update()
    {
        
    }
}
