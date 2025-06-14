using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuestView : View<QuestView>
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private Fish _fish;
    [SerializeField] private int _maxFishAmount;

    public event Action<int> QuestFinish;

    public Sprite Icon => _icon;
    public Fish Fish => _fish;

    public int NeedFishAmount => _needFishAmount;
    public int FishAmount => _needFishList.Count;

    private List<Fish> _needFishList = new List<Fish>();

    private int _needFishAmount = 5;

    public void AddFish(Fish fish)
    {
        _needFishList.Add(fish);

        CheckList();
    }

    private void CheckList()
    {
        int minFishAmount = 5;
        int coeficent = 10;

        if (_needFishList.Count >= _needFishAmount)
        {
            _needFishList.Clear();
            QuestFinish?.Invoke(_fish.AmountOffort / coeficent);
            _needFishAmount = UnityEngine.Random.Range(minFishAmount, _maxFishAmount);
        }
    }
}
