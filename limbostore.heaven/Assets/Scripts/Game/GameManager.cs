using Game;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #if UNITY_EDITOR
    public DeathType cheatDeathType;
    #endif
    
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
        
        GUILayout.Label("Deaths: " + manager.currency.Amount.ToString("N0"));
        GUILayout.Label("Skills", EditorStyles.boldLabel);
        for (int i = 0; i < System.Enum.GetNames(typeof(SkillType)).Length; i++)
        {
            GUILayout.Label((SkillType) i + " => " + manager.skillz.CanDo((SkillType) i));
        }

        GUILayout.Label("Deaths (" + manager.currency.GetTotalDeathCount() + ")", EditorStyles.boldLabel);
        manager.currency.PrintDeathsEditor();
        

        if (GUILayout.Button("Open Shop"))
        {
            GameObject.FindObjectOfType<Shop>().OpenShop();
        }
        if (GUILayout.Button("Get Money"))
        {
            manager.currency.AddDeath(manager.cheatDeathType);
        }
    }
}
#endif
