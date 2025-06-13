using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishSellerView : MonoBehaviour
{
    [SerializeField] private FishView _prefab;
    [SerializeField] private GridLayoutGroup _content;

    private List<FishView> _fishViews = new List<FishView>();
    private RectTransform _contentRectTransform;

    public event Action<Fish> Selling;

    public void ReDraw(Dictionary<Fish, int> fishes)
    {
        _contentRectTransform = _content.GetComponent<RectTransform>();
        Clear();

        foreach (var fish in fishes)
        {
            FishView newFishView = Instantiate(_prefab, _content.transform);
            newFishView.Init(fish.Key, fish.Value);
            _fishViews.Add(newFishView);
            _contentRectTransform.sizeDelta = new Vector2(_contentRectTransform.sizeDelta.x, _contentRectTransform.sizeDelta.y + _content.cellSize.y);

            newFishView.Clicked += OnClicked;
        }
    }

    private void OnClicked(Fish fish)
    {
        Selling?.Invoke(fish);
    }

    private void Clear()
    {
        _contentRectTransform.sizeDelta = new Vector2(_contentRectTransform.sizeDelta.x, 0);

        for (int i = _fishViews.Count - 1; i >= 0; i--)
        {
            _fishViews[i].Clicked -= OnClicked;
            Destroy(_fishViews[i].gameObject);
        }

        _fishViews.Clear();
    }
}
