using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<Fish, int> _fishes = new();

    public void AddFish(Fish fish)
    {
        int oneFish = 1;

        if (_fishes.ContainsKey(fish) == false)
            _fishes.Add(fish, oneFish);
        else
            _fishes[fish] += oneFish;
    }

    public void RemoveFish(Fish fish)
    {
        int oneFish = 1;

        if (_fishes.ContainsKey(fish))
        {
            if (_fishes[fish] > 1)
                _fishes[fish] -= oneFish;
            else
                _fishes.Remove(fish);
        }
    }

    public Dictionary<Fish, int> GetFishes()
    {
        return _fishes;
    }

    public bool IsContains(Fish fish) => _fishes.ContainsKey(fish);
}
