using UnityEngine;

public class Tutorial : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Current.currency.TotalAmount > 0)
        {
            this.enabled = false;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (GameManager.Current.currency.TotalAmount > 0)
        {
            this.enabled = false;
            Destroy(gameObject);
        }
    }
}
