public class CurrencyManager
{
    private int availableCoins = 0;
    
    public CurrencyManager()
    {
        availableCoins = 0;
    }

    public int Amount => availableCoins;
    
    /// <summary>
    /// checks if you can afford the item that costs a amount of money
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool CanAfford(int amount)
    {
        return availableCoins >= amount;
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
        availableCoins -= amount;
        return true;
    }

    /// <summary>
    /// Store money into the availableCoins. Returns the total amount stored.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public int Receive(int amount)
    {
        availableCoins += amount;
        return availableCoins;
    }
}