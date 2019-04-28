using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text textElement;

    private int count = -1;
    
    void Update()
    {
        if (count != GameManager.Current.currency.Amount)
        {
            count = GameManager.Current.currency.Amount;
            textElement.SetText(count.ToString("N0"));
        }
    }
}
