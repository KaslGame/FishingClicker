using UnityEngine;

public class UpgradeData : MonoBehaviour
{
    private int _sellBonus;
    private int _fishingBonus;
    private int _catchingBonus;

    public int SellBonus => _sellBonus;
    public int FishingBonus => _fishingBonus;
    public int CatchingBonus => _catchingBonus;

    public void AddSellBonus(int amount)
    {
        if (amount > 0)
            _sellBonus += amount;
    }

    public void AddFishingBonus(int amount)
    {
        if (amount > 0)
            _fishingBonus += amount;
    }

    public void AddCatchingBonus(int amount)
    {
        if (amount > 0)
            _catchingBonus += amount;
    }
}
