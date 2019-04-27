using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public string levelToLoad = "Room";

    public void LoadLevel()
    {
        GameManager.Current.Level.ChangeLevelTo(levelToLoad);
    }
}
