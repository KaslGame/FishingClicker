using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletStorageService : MonoBehaviour
{
    private const string key = "wallet";

    [SerializeField] private Wallet _wallet;

    private StorageWallet _storageWallet = new StorageWallet();
    private IStorageService _storageService;

    private void Awake()
    {
        _storageService = new JsonToFileStorageService();
        
        if (_storageService.Exists(key) == true)
            _storageService.Load<StorageWallet>(key, LoadWallet);
    }

    private void OnEnable()
    {
        _wallet.MoneyChanged += OnMoneyChanged;
        _wallet.ExperienceChanged += OnExperienceChanged;
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= OnMoneyChanged;
        _wallet.ExperienceChanged -= OnExperienceChanged;
    }

    private void OnMoneyChanged(int amount)
    {
        _storageWallet.EnterData(amount, _storageWallet.Experience);
        _storageService.Save(key, _storageWallet);
    }

    private void OnExperienceChanged(int amount)
    {
        _storageWallet.EnterData(_storageWallet.Money, amount);
        _storageService.Save(key, _storageWallet);
    }

    private void LoadWallet(StorageWallet storageWallet)
    {
        if (storageWallet == null)
            return;

        _storageWallet = storageWallet;

        _wallet.AddMoney(_storageWallet.Money);
        _wallet.AddExperience(_storageWallet.Experience);
    }
}
