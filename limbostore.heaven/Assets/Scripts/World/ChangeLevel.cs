using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public string levelToLoad = "Room";

    public bool isDoor = false, isElevator = false, isTreppe = false;
    
    public void LoadLevel()
    {
        if(isTreppe)
            GameManager.Current.PlayTreppeSound();
        if(isElevator)
            GameManager.Current.PlayAufzugSound();
        if(isDoor)
            GameManager.Current.PlayDoorSound();
        GameManager.Current.Level.ChangeLevelTo(levelToLoad);
    }
}
