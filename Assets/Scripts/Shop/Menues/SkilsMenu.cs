using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkilsMenu : Menu
{
    [SerializeField] private SkilsMenuView _buttons;
    [SerializeField] private UpgradeData _upgradeData;
    [SerializeField] private Wallet _wallet;

    private List<SkillView> _skillViews = new List<SkillView>();

    private SkillView _currentSkilView;

    private void Awake()
    {
        _skillViews.AddRange(_buttons.GetComponentsInChildren<SkillView>());

        foreach (SkillView skillView in _skillViews)
            skillView.Click += OnClick;
    }

    private void OnClick(SkillView skillView)
    {
        _currentSkilView = skillView;

        if (skillView.IsBuying == true)
            ButtonMenu.interactable = false;
        else
            ButtonMenu.interactable = true;
    }

    protected override void MakeAction()
    {
        if (_currentSkilView == null)
            return;

        int cost = _currentSkilView.Cost;

        if (_wallet.Exp < cost)
            return;

        _wallet.RemoveExp(cost);

        switch (_currentSkilView.Skill)
        {
            case Skils.Selling:
                _upgradeData.AddSellBonus(_currentSkilView.Bonus);
                break;

            case Skils.Fishing:
                _upgradeData.AddFishingBonus(_currentSkilView.Bonus);
                break;

            case Skils.Catching:
                _upgradeData.AddCatchingBonus(_currentSkilView.Bonus);
                break;
        }

        _currentSkilView.Buy();
        OffButton();
    }

    private void OffButton()
    {
        ButtonMenu.interactable = false;
        _buttons.ChangeBuyButtonText(_currentSkilView.IsBuying);
    }
}
