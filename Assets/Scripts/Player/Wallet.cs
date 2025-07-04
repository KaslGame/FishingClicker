using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money;
    private int _experience;

    public event Action<int> MoneyChanged;
    public event Action<int> ExperienceChanged;

    public int Exp => _experience;
    public int Money => _money;

    public void AddMoney(int amount)
    {
        if (amount <= 0)
            return;

        _money += amount;
        MoneyChanged?.Invoke(_money);
    }

    public void AddExperience(int amount)
    {
        if (amount <= 0)
            return;

        _experience += amount;
        ExperienceChanged?.Invoke(_experience);
    }

    public void RemoveExp(int amount)
    {
        if (amount <= 0)
            return;

        _experience -= amount;
        ExperienceChanged?.Invoke(_experience);
    }

    public void RemoveMoney(int amount)
    {
        if (amount <= 0)
            return;

        _money -= amount;
        MoneyChanged?.Invoke(_money);
    }
}
