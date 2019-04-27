using System.Collections.Generic;
using Game;
using UnityEngine;

public class CurrencyManager
{
    private int availableCurrency = 0;
    private Dictionary<string, int> deaths = new Dictionary<string, int>();
    
    public CurrencyManager()
    {
        availableCurrency = 0;
    }

    public int Amount => availableCurrency;
    
    /// <summary>
    /// checks if you can afford the item that costs a amount of money
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool CanAfford(int amount)
    {
        return availableCurrency >= amount;
    }

    /// <summary>
    /// Purchase something. Return false if you can't afford it.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool Purchase(int amount)
    {
        if (!CanAfford(amount))
            return false;
        availableCurrency -= amount;
        return true;
    }

    public int GetDeathCount(DeathType type)
    {
        return !deaths.ContainsKey(type.name) ? 0 : deaths[type.name];
    }

    public void AddDeath(DeathType type)
    {
        if (!deaths.ContainsKey(type.name))
        {
            deaths.Add(type.name, 1);
            availableCurrency += type.rewardFirstDeath;
        }
        else
        {
            availableCurrency += type.rewardDefault;
        }
    }

    public int GetTotalDeathCount()
    {
        int deathCount = 0;
        foreach (var pair in deaths)
        {
            deathCount += pair.Value;
        }

        return deathCount;
    }

#if UNITY_EDITOR
    public void PrintDeathsEditor()
    {
        foreach (var pair in deaths)
        {
            GUILayout.Label(pair.Key + ": " + pair.Value.ToString("N0"));
        }
    }
#endif

}