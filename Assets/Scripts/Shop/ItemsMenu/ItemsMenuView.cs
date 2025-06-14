using TMPro;
using UnityEngine;

public class ItemsMenuView : MenuView<ItemView>
{
    const string Buy = "Купить";
    const string Sell = "Продано";

    [SerializeField] private TMP_Text _aboutItemText;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private TMP_Text _buyButton;

    protected override void OnClick(ItemView view)
    {
        base.OnClick(view);
        RedrawInfo(view);
    }

    public void RedrawInfo(ItemView view)
    {
        if (view.IsBuying)
            _buyButton.text = Sell;
        else
            _buyButton.text = Buy;

        _cost.text = $"Цена: {view.Cost}";

        switch (view.ItemType)
        {
            case ItemType.Rod:
                _aboutItemText.text = $"Текущий уровень улучшения: {view.Level}\r\nСтанет доступен вылов новой рыбы";
                break;

            case ItemType.FishingNet:
                if (view.Level == 0)
                    _aboutItemText.text = $"Не куплено!\r\nКаждые 25сек добавляется рыба";
                else
                    _aboutItemText.text = $"Текущий уровень улучшения: {view.Level}\r\nУвеличится количество добавляемых рыб";
                break;
        }
    }
}
