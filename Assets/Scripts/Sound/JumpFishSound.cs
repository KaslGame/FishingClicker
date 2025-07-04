using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JumpFishSound : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    [SerializeField] private AudioClip _jumpFish;

    private AudioSource _audioSource;

    private int _needFish = 3;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _inventory.FishAmountChanged += OnFishAmountChanged;
    }

    private void OnDisable()
    {
        _inventory.FishAmountChanged -= OnFishAmountChanged;
    }

    private void OnFishAmountChanged(Dictionary<Fish, int> fishes)
    {
        if (fishes.Count > _needFish)
            _audioSource.PlayOneShot(_jumpFish);
    }
}
