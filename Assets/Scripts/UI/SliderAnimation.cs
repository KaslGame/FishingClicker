using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderAnimation : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangeSliderValue(float targetValue, int maxValue, Action callback)
    {
        _slider.maxValue = maxValue;
        _slider.value = targetValue;

        if (_slider.value == _slider.maxValue)
        {
            callback();
            _slider.value = 0;
        }
    }
}
