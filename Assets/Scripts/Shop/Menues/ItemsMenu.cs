using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMenu : Menu
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ItemsMenuView _buttons;

    private List<ItemView> _itemsViews = new List<ItemView>();

    private ItemView _currentView;

    private void Awake()
    {
        _itemsViews.AddRange(_buttons.GetComponentsInChildren<ItemView>());

        foreach (ItemView itemView in _itemsViews)
            itemView.Click += OnClick;
    }

    private void OnClick(ItemView itemView)
    {
        _currentView = itemView;

        CheckIsBuying(itemView.CheckIsBuying());
    }

    protected override void MakeAction()
    {
        if (_currentView == null && _currentView.CheckIsBuying() == true)
            return;

        int cost = _currentView.Cost;

        if (_wallet.Money < cost)
            return;

        _wallet.RemoveMoney(cost);

        _currentView.Buy();
        CheckIsBuying(_currentView.CheckIsBuying());
        _buttons.RedrawInfo(_currentView);
    }

    private void CheckIsBuying(bool isBuying)
    {
        if (isBuying == true)
            ButtonMenu.interactable = false;
        else
            ButtonMenu.interactable = true;
    }
}
