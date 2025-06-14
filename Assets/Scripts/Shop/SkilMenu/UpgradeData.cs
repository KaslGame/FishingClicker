using System.Collections.Generic;
using UnityEngine;

public class UpgradeData : MonoBehaviour
{
    [SerializeField] private List<Fish> _allFishList = new();
    [SerializeField] private FishList _fishList;
    [SerializeField] private ItemView _rodView;

    private int _sellBonus;
    private int _fishingBonus;
    private int _catchingBonus;

    public int SellBonus => _sellBonus;
    public int FishingBonus => _fishingBonus;
    public int CatchingBonus => _catchingBonus;
    public int Count => _allFishList.Count;

    private void OnEnable()
    {
        _rodView.LevelChanged += OnLevelChanged;
    }

    private void OnDisable()
    {
        _rodView.LevelChanged -= OnLevelChanged;
    }

    private void OnLevelChanged(int level)
    {
        _fishList.Add(_allFishList[level - 1]);
    }

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
