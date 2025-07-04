using UnityEngine;

public class FishAddSpawner : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private FishAdd _prefab;

    private void Start()
    {
        _inventory.FishAdded += OnFishAdded;
    }

    private void OnDisable()
    {
        _inventory.FishAdded -= OnFishAdded;
    }

    private void OnFishAdded(Sprite icon)
    {
        FishAdd fishAdd = Instantiate(_prefab, transform);
        fishAdd.Init(icon);
    }
}
