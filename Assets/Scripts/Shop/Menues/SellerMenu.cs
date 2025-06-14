using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellerMenu : Menu
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private FishSellerView _fishSellerView;
    [SerializeField] private UpgradeData _upgradeData;

    protected override void OnEnable()
    {
        base.OnEnable();

        _fishSellerView.ReDraw(_inventory.GetFishes());
        _fishSellerView.Selling += OnSelling;
    }

    private void OnDisable()
    {
        _fishSellerView.Selling -= OnSelling;
    }

    public void OnSelling(Fish fish)
    {
        _wallet.AddMoney(GetCost(fish.Cost));
        _inventory.RemoveFish(fish);
        _fishSellerView.ReDraw(_inventory.GetFishes());
    }

    protected override void MakeAction()
    {
        Dictionary<Fish, int> fishes = _inventory.GetFishes();
        List<Fish> fishList = new List<Fish>();

        foreach (int amount in _inventory.GetFishes().Values)
        {
            foreach (Fish fish in fishes.Keys)
            {
                for (int i = 0; i < amount; i++)
                {
                    _wallet.AddMoney(GetCost(fish.Cost));
                    fishList.Add(fish);
                }
            }
        }

        for (int i = fishList.Count - 1; i >= 0; i--)
        {
            fishes.Remove(fishList[i]);
            fishList.Remove(fishList[i]);
        }

        _fishSellerView.ReDraw(_inventory.GetFishes());
    }

    private int GetCost(int normalCost)
    {
        int multiplier = 100;

        int percent = (normalCost * _upgradeData.SellBonus) / multiplier;

        return normalCost + percent;
    }
}
