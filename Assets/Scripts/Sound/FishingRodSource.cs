using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(FishingRod))]
public class FishingRodSource : MonoBehaviour
{
    private FishingRod _fishingRod;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _fishingRod = GetComponent<FishingRod>();
    }

    private void OnEnable()
    {
        _fishingRod.FishSelected += OnFishSelected;
        _fishingRod.FishCatched += OnFishCatched;
    }

    private void OnDisable()
    {
        _fishingRod.FishSelected -= OnFishSelected;
        _fishingRod.FishCatched -= OnFishCatched;
    }

    private void OnFishSelected(Fish fish)
    {
        _audioSource.Play();
        _audioSource.loop = true;
    }

    private void OnFishCatched()
    {
        _audioSource.loop = false;
        _audioSource.Stop();
    }
}
