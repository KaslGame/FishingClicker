using UnityEngine;
using UnityEngine.UI;

public class FishBar : MonoBehaviour
{
    [SerializeField] private FishingRod _fishingRod;
    [SerializeField] private SliderAnimation _sliderAnimation;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Image _icon;

    private void OnEnable()
    {
        _fishingRod.FishSelected += OnFishSelected;
        _fishingRod.Click += OnClick;
    }

    private void OnDisable()
    {
        _fishingRod.FishSelected -= OnFishSelected;
        _fishingRod.Click -= OnClick;
    }

    private void OnFishSelected(Fish fish)
    {
        _icon.sprite = fish.Icon;
    }

    private void OnClick(int amount, int maxAmount)
    {
        _sliderAnimation.ChangeSliderValue(amount, maxAmount, Finish);
    }

    private void Finish()
    {
        _icon.sprite = _defaultSprite;
    }
}
