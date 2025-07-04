using System.Collections.Generic;
using UnityEngine;

public class FishStorageService : MonoBehaviour
{
    private const string key = "Fish";

    [SerializeField] private List<Fish> _allFish = new();
    [SerializeField] private Inventory _inventory;

    private List<FishData> _saveFishes = new List<FishData>();
    private IStorageService _storageService;

    private void Awake()
    {
        _storageService = new JsonToFileStorageService();

        if (_storageService.Exists(key) == true)
            _storageService.Load<List<FishData>>(key, LoadFish);
    }

    private void OnEnable()
    {
        _inventory.FishAmountChanged += OnFishAdded;
    }

    private void OnDisable()
    {
        _inventory.FishAmountChanged -= OnFishAdded;
    }

    private void OnFishAdded(Dictionary<Fish, int> fishes)
    {
        var saveList = new List<FishData>();

        foreach (var pair in fishes)
        {
            saveList.Add(new FishData
            {
                FishID = pair.Key.ID,
                Count = pair.Value
            });
        }

        _storageService.Save(key, saveList);
    }

    private void LoadFish(List<FishData> savedFishes)
    {
        foreach (FishData saveData in savedFishes)
        {
            int fishCount;
            Fish fish = _allFish.Find(f => f.ID == saveData.FishID);
            
            if (fish != null)
            {
                fishCount = saveData.Count;

                for (int i = 0; i < fishCount; i++)
                    _inventory.AddFish(fish);
            }
        }
    }
}
