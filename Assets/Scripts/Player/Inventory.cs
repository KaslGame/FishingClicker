using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Fish> _fishList;

    public void AddFish(Fish fish)
    {
        _fishList.Add(fish);
    }
}
