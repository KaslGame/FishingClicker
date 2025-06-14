using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNet : MonoBehaviour
{
    [SerializeField] private float _cooldown = 25f;
    [SerializeField] private FishList _fishList;
    [SerializeField] private Inventory _inventory;

    private int _fishAmount;

    public void AddFishAmount(int amount)
    {
        int firstFish = 1;

        if (amount > 0)
            _fishAmount += amount;

        if (_fishAmount == firstFish)
            StartCoroutine(CathingFish());
    }

    private IEnumerator CathingFish()
    {
        while (_fishAmount > 0)
        {
            WaitForSeconds wait = new WaitForSeconds(_cooldown);

            yield return wait;

            for (int i = 0; i < _fishAmount; i++)
                _inventory.AddFish(_fishList.GetRandomFish());
        }
    }
}
