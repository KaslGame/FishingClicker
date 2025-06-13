using System;
using UnityEngine;

public class SkillView : View
{
    [SerializeField] private Skils _skill;
    [SerializeField] private int _bonus;
    [SerializeField] private int _cost;

    public event Action<SkillView> Click;

    public Skils Skill => _skill;
    public int Bonus => _bonus;
    public int Cost => _cost;

    public bool IsBuying => _isBuying;

    private bool _isBuying = false;

    public void Buy()
    {
        _isBuying = true;
    }

    protected override void Clicked()
    {
        Click?.Invoke(this);
    }
}

public enum Skils
{
    Selling,
    Fishing,
    Catching
}
