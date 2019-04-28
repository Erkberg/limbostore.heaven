using Game;
using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class BaseDeathTrigger : MonoBehaviour
{
    public DeathType deathType;

    public void TriggerDeath()
    {
        GameManager.Current.TriggerDeath(deathType);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(BaseDeathTrigger))]
public class BaseDeathTriggerEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        target.name = (target as BaseDeathTrigger).deathType.name;
    }
} 
#endif
