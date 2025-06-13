using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkilsMenuView : MonoBehaviour
{
    const string Buy = "������";
    const string Sell = "�������";

    [SerializeField] private TMP_Text _cost;
    [SerializeField] private TMP_Text _bonus;
    [SerializeField] private TMP_Text _buyButton;

    private List<SkillView> _skillViews = new List<SkillView>();

    private void Awake()
    {
        _skillViews.AddRange(gameObject.GetComponentsInChildren<SkillView>());

        foreach (SkillView skillView in _skillViews)
            skillView.Click += OnClick;
    }

    private void OnClick(SkillView skillView)
    {
        ActivateFrame(skillView);
        ChangeBuyButtonText(skillView.IsBuying);
        _cost.text = $"����: {skillView.Cost} EXP";
        
        switch (skillView.Skill)
        {
            case Skils.Selling:
                _bonus.text = $"�����: +{skillView.Bonus}% � �������";
                break;

            case Skils.Fishing:
                _bonus.text = $"����: +{skillView.Bonus}% �������� �������";
                break;

            case Skils.Catching:
                _bonus.text = $"����: +{skillView.Bonus}% �������� ������";
                break;
        }
    }

    private void ActivateFrame(SkillView newSkillView)
    {
        foreach (SkillView skillView in _skillViews)
            skillView.ChangeActiveFrame(false);

        newSkillView.ChangeActiveFrame(true);
    }

    public void ChangeBuyButtonText(bool isBuying)
    {
        if (isBuying)
            _buyButton.text = Sell;
        else
            _buyButton.text = Buy;
    }
}
