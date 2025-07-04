using System.Collections.Generic;
using UnityEngine;

public class SkilsMenu : Menu
{
    private const string Key = "Skills";

    [SerializeField] private SkilsMenuView _buttons;
    [SerializeField] private UpgradeData _upgradeData;
    [SerializeField] private Wallet _wallet;

    private List<SkillView> _skillViews = new List<SkillView>();

    private SkillView _currentSkilView;
    private IStorageService _storageService;

    private List<bool> _skillViewsBuying = new();

    private void Awake()
    {
        _skillViews.AddRange(_buttons.GetComponentsInChildren<SkillView>());

        foreach (SkillView skillView in _skillViews)
            skillView.Click += OnClick;

        _storageService = new JsonToFileStorageService();

        if (_storageService.Exists(Key) == true)
            _storageService.Load<List<bool>>(Key, LoadSkill);
    }

    private void OnClick(SkillView skillView)
    {
        _currentSkilView = skillView;

        if (skillView.IsBuying == true)
            ButtonMenu.interactable = false;
        else
            ButtonMenu.interactable = true;
    }

    private void Save()
    {
        _skillViewsBuying.Clear();

        foreach (SkillView skillView in _skillViews)
            _skillViewsBuying.Add(skillView.IsBuying);

        _storageService.Save(Key, _skillViewsBuying);
    }

    private void LoadSkill(List<bool> listBools)
    {
        for (int i = 0; i < listBools.Count; i++)
        {
            if (listBools[i] == true)
                _skillViews[i].Buy();
        }
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
        Save();
        BuySound.PlayBuySound();
    }

    private void OffButton()
    {
        ButtonMenu.interactable = false;
        _buttons.ChangeBuyButtonText(_currentSkilView.IsBuying);
    }
}
