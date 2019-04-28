using Game;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #if UNITY_EDITOR
    public DeathType cheatDeathType;
    public bool NeverDie = false;
    #endif

    public DeathScreen deathScreen;
    public IntroOutroScreen outroScreen;

    public AudioSource source;
    public AudioClip collectableSound, doorSound, elevatorSound, treppeSound;

    public bool PlayerLocked
    {
        get;
        private set;
    }

    private CurrencyManager currencyManager = new CurrencyManager();
    private EventManager eventManager = new EventManager();
    private CollectablesManager collectablesManager = new CollectablesManager();
    private SkillManager skillzManager = new SkillManager();
    [SerializeField]
    private LevelManager levelManager;
    
    public CurrencyManager currency => currencyManager;
    public EventManager events => eventManager;
    public CollectablesManager collectables => collectablesManager;
    public SkillManager skillz => skillzManager;
    public LevelManager Level => levelManager;
    
    public static GameManager Current { private set; get; }

    
    public void TriggerDeath(DeathType deathType)
    {
        if (PlayerLocked)
            return;
        
        bool isFirstDeath = currencyManager.GetDeathCount(deathType) == 0;
        currencyManager.AddDeath(deathType);
        
        events.TriggerEvent(EventManager.EventType.Death, deathType.name);
        
#if UNITY_EDITOR
        if (NeverDie)
            return;
#endif
        
        deathScreen.DisplayDeathType(deathType, isFirstDeath);
        PlayerLocked = true;
        
    }

    public void PlayCollectableSound()
    {
        source.PlayOneShot(collectableSound);   
    }

    public void PlayDoorSound()
    {
        source.PlayOneShot(doorSound);   

    }

    public void PlayTreppeSound()
    {
        source.PlayOneShot(treppeSound);   
    }

    public void PlayAufzugSound()
    {
        source.PlayOneShot(elevatorSound);   
    }

    public void Restart(float delayTime)
    {
        Invoke(nameof(ReturnFromTheDead), delayTime);
        events.TriggerEvent(EventManager.EventType.NewGame);
    }

    void ReturnFromTheDead()
    {
        PlayerLocked = false;
    }

    public void SetPlayerLocked(bool locked)
    {
        PlayerLocked = locked;
    }

    public void EndGame()
    {
        outroScreen.Show();
    }
    
    void Awake()
    {
#if !UNITY_EDITOR
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
#endif
        Current = this;
        events.GameIsStarting.AddListener(ReturnFromTheDead);
        // TODO: somewhere else
        events.TriggerEvent(EventManager.EventType.GameIsStarting);
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.C))
        {
            // cheat!!
            for (int i = 0; i < System.Enum.GetNames(typeof(SkillType)).Length; i++)
            {
                skillz.AddSkill((SkillType) i);
            }
            currency.AddDeath(cheatDeathType);
            for (int i = 0; i < System.Enum.GetNames(typeof(CollectableName)).Length; i++)
            {
                collectables.AddCollectable((CollectableName) i);
            }
            collectables.hasAllCollectables = true;
        }
        #endif
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        GameManager manager = target as GameManager;
        if (manager == null)
            return;
        
        GUILayout.Label("Currency: " + manager.currency.Amount.ToString("N0"));
        GUILayout.Label("Skills", EditorStyles.boldLabel);
        for (int i = 0; i < System.Enum.GetNames(typeof(SkillType)).Length; i++)
        {
            GUILayout.Label((SkillType) i + " => " + manager.skillz.CanDo((SkillType) i));
        }

        GUILayout.Label("Deaths (" + manager.currency.GetTotalDeathCount() + ")", EditorStyles.boldLabel);
        manager.currency.PrintDeathsEditor();
        GUILayout.Label("Collectables", EditorStyles.boldLabel);
        manager.collectables.PrintEditor();
        

        if (GUILayout.Button("Open Shop"))
        {
            GameObject.FindObjectOfType<Shop>().OpenShop();
        }
        if (GUILayout.Button("Get Money"))
        {
            manager.currency.AddDeath(manager.cheatDeathType);
        }
        if (GUILayout.Button("End Game"))
        {
            manager.EndGame();
        }
    }
}
#endif
