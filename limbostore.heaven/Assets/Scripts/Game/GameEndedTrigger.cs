using UnityEngine;

public class GameEndedTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Current.EndGame();
    }
}
