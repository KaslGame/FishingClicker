using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Barrel : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private int _minFishAmount = 3;
    [SerializeField] private Sprite _default;
    [SerializeField] private Sprite _full;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _inventory.FishAmountChanged += OnFishAmountChanged;
    }

    private void OnDisable()
    {
        _inventory.FishAmountChanged -= OnFishAmountChanged;
    }

    private void OnFishAmountChanged(Dictionary<Fish, int> dictionary)
    {
        if (dictionary.Count >= _minFishAmount)
            _spriteRenderer.sprite = _full;
        else
            _spriteRenderer.sprite = _default;
    }
}
