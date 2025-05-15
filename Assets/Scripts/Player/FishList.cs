using System.Collections.Generic;
using UnityEngine;

public class FishList : MonoBehaviour
{
    [SerializeField] private List<Fish> _fishList;

    public Fish GetRandomFish()
    {
        return _fishList[Random.Range(0, _fishList.Count)];
    }
}
