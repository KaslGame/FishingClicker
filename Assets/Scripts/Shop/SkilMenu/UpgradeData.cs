using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeData : MonoBehaviour
{
    private const string Key = "Upgrade";

    [SerializeField] private List<Fish> _allFishList = new();
    [SerializeField] private FishList _fishList;
    [SerializeField] private ItemView _rodView;

    private IStorageService _storageService;

    private int _sellBonus;
    private int _fishingBonus;
    private int _catchingBonus;
    private int _level;

    public int SellBonus => _sellBonus;
    public int FishingBonus => _fishingBonus;
    public int CatchingBonus => _catchingBonus;
    public int Count => _allFishList.Count;

    private void Awake()
    {
        _storageService = new JsonToFileStorageService();

        if (_storageService.Exists(Key) == true)
            _storageService.Load<DataUpgrades>(Key, LoadSkill);
    }

    private void OnEnable()
    {
        _rodView.LevelChanged += OnLevelChanged;
    }

    private void OnDisable()
    {
        _rodView.LevelChanged -= OnLevelChanged;
    }

    private void LoadSkill(DataUpgrades dataUpgrades)
    {
        _sellBonus = dataUpgrades.SellBonus;
        _fishingBonus = dataUpgrades.FishingBonus;
        _catchingBonus = dataUpgrades.CatchingBonus;
        _level = dataUpgrades.Level;

        for (int i = 0; i < _level; i++)
        {
            _fishList.Add(_allFishList[i]);
        }
    }

    private void Save()
    {
        DataUpgrades dataUpgrades = new DataUpgrades();

        dataUpgrades.SellBonus = _sellBonus;
        dataUpgrades.FishingBonus = _fishingBonus;
        dataUpgrades.CatchingBonus = _catchingBonus;
        dataUpgrades.Level = _level;

        _storageService.Save(Key, dataUpgrades);
    }

    private void OnLevelChanged(int level)
    {
        _level = level;
        _fishList.Add(_allFishList[level - 1]);
        Save();
    }

    public void AddSellBonus(int amount)
    {
        if (amount > 0)
            _sellBonus += amount;

        Save();
    }

    public void AddFishingBonus(int amount)
    {
        if (amount > 0)
            _fishingBonus += amount;

        Save();
    }

    public void AddCatchingBonus(int amount)
    {
        if (amount > 0)
            _catchingBonus += amount;

        Save();
    }
}
