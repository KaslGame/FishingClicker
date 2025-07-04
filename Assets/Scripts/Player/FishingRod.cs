using System;
using UnityEngine;
using UnityEngine.UI;

public class FishingRod : MonoBehaviour
{
    [SerializeField] private FishList _allFishList;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Button _clickButton;
    [SerializeField] private UpgradeData _upgradeData;

    public event Action<Fish> FishSelected;
    public event Action FishCatched;
    public event Action<int, int> Click;

    private Fish _currentFish;
    private bool _fishing = false;
    private int _clicksAmount = 1;
    private int _countClicks;

    private void OnEnable()
    {
        _clickButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _clickButton.onClick.RemoveListener(OnClick);
    }

    public void OnClick()
    {
        if (TryChance(_upgradeData.FishingBonus))
            _clicksAmount = 2;
        else
            _clicksAmount = 1;

        if (_fishing == false)
            StartFishing();

        _countClicks += _clicksAmount;
        Click?.Invoke(_countClicks, _currentFish.AmountOffort);

        TryCatchFish();
    }

    private void StartFishing()
    {
        _currentFish = _allFishList.GetRandomFish();
        FishSelected?.Invoke(_currentFish);
        _fishing = true;
    }

    private bool TryChance(int needChance)
    {
        int maxChance = 100;
        int minChance = 0;
        float chance = UnityEngine.Random.Range(minChance, maxChance);

        if (chance <= needChance)
            return true;

        return false;

    }

    private void TryCatchFish()
    {
        if (_countClicks >= _currentFish.AmountOffort)
        {
            if (TryChance(_upgradeData.CatchingBonus))
                _inventory.AddFish(_currentFish);

            _inventory.AddFish(_currentFish);
            _fishing = false;
            _countClicks = 0;
            FishCatched?.Invoke();
        }
    }
}
