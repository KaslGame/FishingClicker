using System;
using UnityEngine;

public class ItemView : View<ItemView>
{
    private const string Item = nameof(Item);

    [SerializeField] private UpgradeData _fishList;
    [SerializeField] FishingNet _fishingNet;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private int _cost = 100;
    [SerializeField] private int _level = 0;

    public int Level => _level;
    public int Cost => _cost;
    public bool IsBuying { get; private set; }
    public ItemType ItemType => _itemType;

    public event Action<int> LevelChanged;

    private int _fishAmount;
    private int _maxFishAmount = 5;


    private IStorageService _storageService;

    protected override void Awake()
    {
        base.Awake();

        _storageService = new JsonToFileStorageService();

        if (_storageService.Exists(Item+_itemType) == true)
            _storageService.Load<ItemData>(Item + _itemType, LoadItem);
    }

    private void LoadItem(ItemData itemData)
    {
        _level = itemData.Level;
        IsBuying = itemData.IsBuying;
        _cost = itemData.Cost;
    }

    private void Save()
    {
        var itemData = new ItemData();
        itemData.Level = _level;
        itemData.IsBuying = IsBuying;
        itemData.Cost = _cost;

        _storageService.Save(Item + _itemType, itemData);
    }

    public void Buy()
    {
        if (_itemType == ItemType.Rod)
        {
            int multiplerRod = 2;

            _cost *= multiplerRod;
            LevelChanged?.Invoke(Level);
        }
        else if (_itemType == ItemType.FishingNet)
        {
            int multiplerFishingNet = 3;
            int oneFish = 1;

            _cost *= multiplerFishingNet;
            _fishingNet.AddFishAmount(oneFish);
            _fishAmount += oneFish;
        }

        _level++;
        Save();
    }

    public bool CheckIsBuying()
    {
        if (_fishList.Count < Level && _itemType == ItemType.Rod)
            IsBuying = true;
        else if (_fishAmount >= _maxFishAmount)
            IsBuying = true;

        return IsBuying;
    }
}

public enum ItemType
{
    Rod,
    FishingNet
}
