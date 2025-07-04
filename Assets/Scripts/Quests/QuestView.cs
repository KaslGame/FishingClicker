using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuestView : View<QuestView>
{
    private const string Key = "quests";

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

    private IStorageService _storageService;

    private void Start()
    {
        int minFishAmount = 5;

        _storageService = new JsonToFileStorageServiceAsync();

        if (_storageService.Exists(Key + _fish.ID))
            LoadData();
        else
            _needFishAmount = minFishAmount;
    }

    public void AddFish(Fish fish, int amount = 1)
    {
        for (int i = 0; i < amount; i++)
            _needFishList.Add(fish);

        CheckList();

        SaveData();
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

    private void SaveData()
    {
        var data = new QuestData
        {
            FishAmount = _needFishList.Count,
            NeedFishAmount = _needFishAmount
        };

        _storageService.Save(Key + _fish.ID, data);
    }

    private void LoadData()
    {
        _storageService.Load<QuestData>(Key + _fish.ID, data =>
        {
            _needFishAmount = data.NeedFishAmount;
            _needFishList = new List<Fish>();

            for (int i = 0; i < data.FishAmount; i++)
                _needFishList.Add(_fish); 
        });
    }
}
