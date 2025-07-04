using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CatchSource : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    [SerializeField] private AudioClip _catch;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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
        _audioSource.PlayOneShot(_catch);
    }
}
