using TMPro;
using UnityEngine;

public class SkilsMenuView : MenuView<SkillView>
{
    const string Buy = "Купить";
    const string Sell = "Продано";

    [SerializeField] private TMP_Text _cost;
    [SerializeField] private TMP_Text _bonus;
    [SerializeField] private TMP_Text _buyButton;

    protected override void OnClick(SkillView skillView)
    {
        base.OnClick(skillView);
        ChangeBuyButtonText(skillView.IsBuying);
        _cost.text = $"Цена: {skillView.Cost} EXP";

        switch (skillView.Skill)
        {
            case Skils.Selling:
                _bonus.text = $"Бонус: +{skillView.Bonus}% к продаже";
                break;

            case Skils.Fishing:
                _bonus.text = $"Шанс: +{skillView.Bonus}% двойному нажатию";
                break;

            case Skils.Catching:
                _bonus.text = $"Шанс: +{skillView.Bonus}% двойному вылову";
                break;
        }
    }

    public void ChangeBuyButtonText(bool isBuying)
    {
        if (isBuying)
            _buyButton.text = Sell;
        else
            _buyButton.text = Buy;
    }
}
