using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Inventory))]
public class PlayerAnimation : MonoBehaviour
{
    private const string Hook = nameof(Hook);

    private Inventory _inventory;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _inventory = GetComponent<Inventory>();
    }

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
        _animator.SetTrigger(Hook);
    }
}
