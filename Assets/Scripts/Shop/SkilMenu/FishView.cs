using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _amount;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button _sellButton;

    public event Action<Fish> Clicked;

    private Fish _currentFish;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnClick);
    }

    public void Init(Fish fish, int amount)
    {
        _icon.sprite = fish.Icon;
        _amount.text = $"Количество: {amount}";
        _cost.text = fish.Cost.ToString();

        _currentFish = fish;
    }

    private void OnClick()
    {
        Clicked?.Invoke(_currentFish);
    }
}
