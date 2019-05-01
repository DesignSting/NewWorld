using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootList
{
    public string name;
    public int amount;

    public LootList(string newName, int newAmount)
    {
        name = newName;
        amount = newAmount;
    }
}
