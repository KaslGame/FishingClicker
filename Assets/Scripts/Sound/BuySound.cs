using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BuySound : MonoBehaviour
{
    [SerializeField] private AudioClip _buySound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayBuySound()
    {
        _audioSource.PlayOneShot(_buySound);
    }
}
