using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private TMP_Text _money;

    private void Awake()
    {
        _money = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _wallet.MoneyChanged += OnMoneyChanged;
        OnMoneyChanged(_wallet.Money);
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int amount)
    {
        _money.text = amount.ToString();
    }
}
