using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money;
    private int _exp;

    public event Action<int> MoneyChanged;
    public event Action<int> ExpChanged;

    public int Exp => _exp;
    public int Money => _money;

    public void AddMoney(int amount)
    {
        if (amount <= 0)
            return;

        _money += amount;
        MoneyChanged?.Invoke(_money);
    }

    public void AddExp(int amount)
    {
        if (amount <= 0)
            return;

        _exp += amount;
        ExpChanged?.Invoke(_exp);
    }

    public void RemoveExp(int amount)
    {
        if (amount <= 0)
            return;

        _exp -= amount;
        ExpChanged?.Invoke(_exp);
    }

    public void RemoveMoney(int amount)
    {
        if (amount <= 0)
            return;

        _money -= amount;
        MoneyChanged?.Invoke(_money);
    }
}
