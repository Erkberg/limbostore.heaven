using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string sceneToStart = "Wohnzimmer";
    
    [SerializeField]
    private string currentLevel = "";

    public string[] mainScenes = new string[]
    {
        "Main", "Management"
    };

    
    void Start()
    {
        GameManager.Current.events.NewGame.AddListener(LoadStartLevel);
        CheckForMainLevels();
        ChangeLevelTo(sceneToStart);
    }

    void LoadStartLevel()
    {
        ChangeLevelTo(sceneToStart);
    }
    
    void CheckForMainLevels()
    {
        List<string> scenes = new List<string>();
        foreach (var scene in mainScenes)
        {
            scenes.Add(scene);
        }

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (scenes.Contains(SceneManager.GetSceneAt(i).name))
            {
                scenes.Remove(SceneManager.GetSceneAt(i).name);
            }
        }

        foreach (var scene in scenes)
        {
            Debug.Log("[Level] Loading helper scene " + scene);
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
    }

    public void ChangeLevelTo(string scene)
    {
        if (scene == currentLevel)
        {
            Debug.Log("[Level] Scene " + scene + " is already loaded.");
            return;
        }

        if (currentLevel != "")
        {
            string level = currentLevel;
            var op = SceneManager.UnloadSceneAsync(currentLevel, UnloadSceneOptions.None);
            op.completed += (value) =>
            {
                Debug.Log("[Level] Scene " + level + " was unloaded.");
            };
        }

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (scene == SceneManager.GetSceneAt(i).name)
            {
                // Level is already loaded
                currentLevel = scene;
                Debug.Log("[Level] Stopping scene load, scene " + scene + " already loaded.");

                return;
            }
        }

        Debug.Log("[Level] Loading scene " + scene);

        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        currentLevel = scene;
    }
}
