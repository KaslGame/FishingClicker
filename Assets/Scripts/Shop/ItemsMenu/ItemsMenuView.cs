using TMPro;
using UnityEngine;

public class ItemsMenuView : MenuView<ItemView>
{
    const string Buy = "������";
    const string Sell = "�������";

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

        _cost.text = $"����: {view.Cost}";

        switch (view.ItemType)
        {
            case ItemType.Rod:
                _aboutItemText.text = $"������� ������� ���������: {view.Level}\r\n������ �������� ����� ����� ����";
                break;

            case ItemType.FishingNet:
                if (view.Level == 0)
                    _aboutItemText.text = $"�� �������!\r\n������ 25��� ����������� ����";
                else
                    _aboutItemText.text = $"������� ������� ���������: {view.Level}\r\n���������� ���������� ����������� ���";
                break;
        }
    }
}
