using System;
using UnityEngine;
using UnityEngine.UI;

public class FishingRod : MonoBehaviour
{
    [SerializeField] private FishList _allFishList;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Button _clickButton;

    public event Action<Fish> FishSelected;
    public event Action<int, int> Click;

    private Fish _currentFish;
    private bool _fishing = false;
    private int _multiplierClicks = 1;
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
        int oneClick = 1;
        int clickCount = oneClick * _multiplierClicks;

        if (_fishing == false)
            StartFishing();

        _countClicks += clickCount;
        Click?.Invoke(_countClicks, _currentFish.AmountOffort);

        TryCatchFish();
    }

    private void StartFishing()
    {
        _currentFish = _allFishList.GetRandomFish();
        FishSelected?.Invoke(_currentFish);
        _fishing = true;
    }

    private void TryCatchFish()
    {
        if (_countClicks >= _currentFish.AmountOffort)
        {
            _inventory.AddFish(_currentFish);
            _fishing = false;
            _countClicks = 0;
        }
    }
}
