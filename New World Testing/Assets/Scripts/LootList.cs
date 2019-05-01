using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootList
{
    public string name;
    public int amount;
    public int coinsGained;

    public LootList(string newName, int newAmount, int newCoinsGained)
    {
        name = newName;
        amount = newAmount;
        coinsGained = newCoinsGained;
    }
}
