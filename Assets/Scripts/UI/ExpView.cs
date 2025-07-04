using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private TMP_Text _exp;

    private void Awake()
    {
        _exp = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _wallet.ExperienceChanged += OnExpChanged;
    }

    private void OnDisable()
    {
        _wallet.ExperienceChanged -= OnExpChanged;
    }

    private void OnExpChanged(int amount)
    {
        _exp.text = amount.ToString();
    }
}
