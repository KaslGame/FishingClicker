using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fish", menuName = "Create fish/ New Fish")]
public class Fish : ScriptableObject
{
    public Sprite Icon;
    public int ID;
    public int AmountOffort;
    public int Cost;
}